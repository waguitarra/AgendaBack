using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Api.Domain.Interfaces;
using NLog;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUUserRepository _repository;
        public SigningConfigurations _signingConfigurations;
        private IRepository<UserEntity> _iUserRepositer;
        private Logger _logger;
        private IConfiguration _configuration { get; }


        public LoginService(IUUserRepository repository,
                            SigningConfigurations signingConfigurations,
                            IConfiguration configuration,
                            IRepository<UserEntity> iUserRepositer                           
                            )
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
            _iUserRepositer = iUserRepositer;
            _logger  = LogManager.GetCurrentClassLogger();
 
        }


        public async Task<object> FindByLogin(LoginDto user)
        {

            var baseUser = new UserEntity();
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.FindByLogin(user.Email);
                _logger.Debug($"Usuario logado : {user.Email}");
                //criando parametro de salto de criptografia
                if (baseUser == null || baseUser.Ativo == false) {
                    _logger.Debug($"Usuario não existe : {user.Email}");
                    return "Usuario não existe";
                }
                   


                var match = Validate(user.PassWord, baseUser.TokenRedes, baseUser.Password);
                if (match)
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Email),
                    new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                        }
                    );

                    DateTime createDate = DateTime.UtcNow;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds")));

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);

                    //Add UserLogado na base de datos
                    baseUser.UserLogado = expirationDate;
                    await _iUserRepositer.UpdateAsync(baseUser);

                    var listEntity = await _iUserRepositer.SelectAsync(baseUser.Id);
                    listEntity.UserLogado = DateTime.Now;
                    await _iUserRepositer.UpdateAsync(listEntity);

                    return SuccessObject(createDate, expirationDate, token, baseUser);


                }
                else
                {
                    _logger.Debug($"Falha ao autenticar");
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }

            }
            else
            {
                _logger.Debug($"Falha ao autenticar");
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity user)
        {
            return new
            {
                authenticated = true,
                create = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                idUsuario = user.Id,
                nome = user.Nome,
                //name = user.Nome,
                //message = "Usuário Logado com sucesso"
            };
        }


        // Para comparar Criptografia
        public static string Create(string value, string salt)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                                password: value,
                                salt: Encoding.UTF8.GetBytes(salt),
                                prf: KeyDerivationPrf.HMACSHA512,
                                iterationCount: 10000,
                                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }


        public static bool Validate(string value, string salt, string hash) => Create(value, salt) == hash;


        public static string Salt_Create()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

    }
}
