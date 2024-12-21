using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using AutoMapper;
using Domain.Interfaces.Services.EmailsNewsletter;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using NLog;
using Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {

        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;
        private  IEmailsNewsletterService _emailsNewsletterService;
        private ImgurPOSTImagen _imgurPOSTImagen;

        private IUUserRepository _iUserRepository;
        private IUProdutosRepository _produtosRepositorio;
        private IUMensagensPRepository _mensagensRepository;
        private static readonly ILogger _logge = LogManager.GetCurrentClassLogger();

        public UserService(IRepository<UserEntity> repository
                        , IEmailsNewsletterService emailsNewsletterService
                        , IMapper mapper
                        , IUUserRepository IUserRepository
                        , IUMensagensPRepository mensagensRepository                
                        , IUProdutosRepository produtosRepositorio)
        {
            _repository = repository;
            _mapper = mapper;
            _iUserRepository = IUserRepository;
            _produtosRepositorio = produtosRepositorio;
            _emailsNewsletterService = emailsNewsletterService;
            _mensagensRepository = mensagensRepository;

        }

        public async Task<UserDto> Get(Guid id)
        {

            var listEntity = await _repository.SelectAsync(id);

            if (listEntity != null)
            {
                listEntity = await _iUserRepository.GetProdutoPorUserId(id);

                foreach (var Produtos in listEntity.Produtos)
                {
                    await _produtosRepositorio.GetCompleteByMensagensP(Produtos.Id);
                    await _produtosRepositorio.GetCompleteByImagensP(Produtos.Id);
                    await _produtosRepositorio.GetCompleteByCategoria(Produtos.CategoriaId);
                    await _produtosRepositorio.GetCompleteByTipoServico(Produtos.TipoServicoId);
                }

                return _mapper.Map<UserDto>(listEntity);
            }
            _logge.Warn($"UserId: {id}");
            return null;
        }
        public async Task<UserDtoUpdateResult> DesativarUsuario(Guid id)
        {
    
            var listEntity = await _repository.SelectAsync(id);
            _logge.Debug($"id: {id} email {listEntity.Email}");
            if (listEntity == null)
            {
                return null;
            }
            if (listEntity.Ativo == false)
            {
                listEntity.Ativo = true;
                listEntity.Delete = null;
            }
            else
            {
                listEntity.Ativo = false;
                listEntity.Delete = DateTime.UtcNow;
            }


            if (listEntity != null)
            {

                var baseUser = await _iUserRepository.FindByEmail(listEntity.Email);

                if (baseUser == null)
                {
                    return null;
                }
                else
                {           
                    var entity = _mapper.Map<UserEntity>(listEntity);

                    var result = await _repository.UpdateAsync(entity);
                    return _mapper.Map<UserDtoUpdateResult>(result);
                }
            }
            return null;
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            _logge.Debug($"GetAll:");
            var listEntity = await _repository.SelectAsync();

            foreach (var item in listEntity)
            {
                var users = await _iUserRepository.GetProdutoPorUserId(item.Id);

                foreach (var itemsProdutos in users.Produtos)
                {
                    await _produtosRepositorio.GetCompleteByMensagensP(itemsProdutos.Id);
                    await _produtosRepositorio.GetCompleteByImagensP(itemsProdutos.Id);
                    await _produtosRepositorio.GetCompleteByCategoria(itemsProdutos.CategoriaId);
                    await _produtosRepositorio.GetCompleteByTipoServico(itemsProdutos.TipoServicoId);
                }
            }
            _logge.Warn($":");
            return _mapper.Map<IEnumerable<UserDto>>(listEntity.AsQueryable().OrderByDescending(p => p.CreateAt).ToList());
        }
        public async Task<UserDto> GetProdutoPorUserId(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity);
        }
        public async Task<UserGetDadosBasicosDto> GetProdutoDadosPorUserId(Guid id)
        {
            _logge.Debug($"id: {id}");
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserGetDadosBasicosDto>(entity);
        }
        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            _logge.Debug($"Post: {user.EnviarEmail}");

            string password = user.Password;
            var TokenRedes = SaltCreate();
            var hash = Create(user.Password, TokenRedes);
            user.Password = hash;
            var baseUser = await _iUserRepository.FindByEmail(user.Email);

            if (baseUser != null)
            {
                _logge.Debug($"Email já existe : {user.EnviarEmail}");
                return null;
            }
            else
            {

                //Aqui subimos tudo para servidor Imgur nossas imagens e temos o retorno da url
                //var convert64 =  ImageToBase64(user.ImagemLogin);
                //var UrlImagens =  imgurUpload(convert64);

                var model = _mapper.Map<UserEntity>(user);
                model.TokenRedes = TokenRedes; // temporario por conta de autenticaçao google.
                model.EnviarEmail = true;
                // model.ImagemLogin = UrlImagens;
       
                var result = await _repository.InsertAsync(model);    
                
                //Enviar email de relatorio
                //reportEmail();


                try
                {
                    if (result.Idioma != "es" && result.Idioma != "pt" && result.Idioma != "br")
                    {
                        result.Pais = "es";
                    }
                    //await _emailsNewsletterService.SendEmailPorTipoAsync(1, result.Email, result.Nome, password, null, result.Idioma);
                    return _mapper.Map<UserDtoCreateResult>(result);
                }
                catch (Exception ex)
                {
                    _logge.Error($"Erro : {ex}");
                    _logge.Error($"error  : {ex.Message}");
                    //await _emailsNewsletterService.EmailErros(ex.ToString());
                }
                return null;
            }
        }
        public async Task<UserLatLogDtoUpdate> PutLatitudeLongitude(UserLatLogDtoUpdate user)
        {
            var listEntity = await _repository.SelectAsync(user.Id);

            _logge.Debug($"TrocarSenha: {user.TrocarSenha} Email:{listEntity.Email} termos de responsabilidades{listEntity.TermosResponsabilidades} EnviarEmail: {user.EnviarEmail}");

            if (listEntity == null)
            {
                return null;
            }         
            else
            {
                try
                {
                    var model = _mapper.Map<UserEntity>(listEntity);
                    model.Latitude = user.Latitude; 
                    model.Longitude = user.Longitude;
                    model.Idioma = user.Idioma;
                    model.Pais =  user.Pais;
                    model.Estado = user.Estado;
                    model.CodEstado = user.CodEstado;

                    if (user.TermosResponsabilidades != new Guid("00000000-0000-0000-0000-000000000000"))
                    {
                        model.TermosResponsabilidades = user.TermosResponsabilidades;
                    }

                    model.TokenRedes = listEntity.TokenRedes; 
     
                    var result = await _repository.UpdateAsync(model);               

                    user.Latitude = result.Latitude;
                    user.Longitude = result.Longitude;
                    user.TermosResponsabilidades = result.TermosResponsabilidades;

                    await ArrumarImagensUsuarioId(user.Id);

                    return _mapper.Map<UserLatLogDtoUpdate>(user);
                }
                catch (Exception ex)
                {
                    _logge.Error($"error  : {ex.Message}");
                    _logge.Error($"error  : {ex}");
                    return null;
                }
            }

            
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            string convert64 = "";

            _logge.Debug($"EnviarEmail: {user.EnviarEmail}");
            _logge.Debug($"User: {user}");

            var listEntity = await _repository.SelectAsync(user.Id);
            if (listEntity == null)
            {
                return null;
            }

            //if (user.ImagemLogin.Length > 1000)
            //    convert64 = user.ImagemLogin;
            //else
            //    convert64 = ImageToBase64(user.ImagemLogin);

            //Aqui subimos tudo para servidor Imgur nossas imagens e temos o retorno da url

            var UrlImagens = await  imgurUpload(convert64);

            var baseUser = await _iUserRepository.FindByEmail(listEntity.Email);

            if (baseUser == null)
            {
                return null;
            }
            else
            {
                var model = _mapper.Map<UserEntity>(user);
                model.ImagemLogin = UrlImagens.ToString();
                model.Password = listEntity.Password; //temporario por conta da requisiçao do google
                model.Email = listEntity.Email; //temporario por conta da requisiçao do google
                model.TokenRedes = listEntity.TokenRedes; //temporario por conta da requisiçao do google


                var result = await _repository.UpdateAsync(model);
                return _mapper.Map<UserDtoUpdateResult>(result);
            }
        }

        private async Task<bool> ImagensUsuarioGooglePut() 
        {
            _logge.Debug($"ImagensUsuarioGooglePut");
            var user = await _repository.SelectAsync();
            var tb = 1;
            foreach (var item in user)
            {
                tb = tb + 1;
                //Aqui subimos tudo para servidor Imgur nossas imagens e temos o retorno da url
                var convert64 = ImageToBase64(item.ImagemLogin);
                var UrlImagens = await imgurUpload(convert64);

                var model = _mapper.Map<UserEntity>(item);
                model.ImagemLogin = UrlImagens;         

    
                var result = await _repository.UpdateAsync(model);

            }
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            _logge.Debug($"id: {id}");
            return await _repository.DeleteAsync(id);
        }

        //Gerando Token aleatorio para validacao de usuario
        private static string SaltCreate()
        {
            byte[] randomBytes = new byte[256 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
        private static string Create(string value, string salt)
        {
            _logge.Debug($"value: {value}   salt: {salt} ");
            var valueBytes = KeyDerivation.Pbkdf2(
                                password: value,
                                salt: Encoding.UTF8.GetBytes(salt),
                                prf: KeyDerivationPrf.HMACSHA512,
                                iterationCount: 10000,
                                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

        private string ImageToBase64(string url)
        {
            _logge.Debug($"url: {url}");
            StringBuilder sb = new StringBuilder();

            Byte[] datos = this.GetImage(url);

            sb.Append(Convert.ToBase64String(datos, 0, datos.Length));

            _logge.Debug($"sb.ToString(): {sb}");
            return sb.ToString();
        }

        private byte[] GetImage(string url)
        {
            _logge.Debug($"Original URL: {url}");
            url = url.Replace("\\", "/"); // Normaliza barras invertidas
            _logge.Debug($"Normalized URL: {url}");

            Stream stream = null;
            byte[] buf = null;

            try
            {
                // Valida o formato do URL antes de tentar acessar
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    _logge.Error($"Invalid URL format: {url}");
                    return null; // Retorna nulo se o URL for inválido
                }

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK) // Apenas processa se o status for OK
                    {
                        _logge.Debug("Image fetched successfully.");
                        stream = response.GetResponseStream();

                        using (BinaryReader br = new BinaryReader(stream))
                        {
                            int len = (int)response.ContentLength;
                            buf = br.ReadBytes(len);
                        }
                    }
                    else
                    {
                        _logge.Warn($"Server responded with status: {response.StatusCode} ({response.StatusDescription})");
                    }
                }
            }
            catch (WebException webEx)
            {
                // Captura erros HTTP e loga sem interromper
                if (webEx.Response is HttpWebResponse errorResponse)
                {
                    _logge.Error($"WebException: HTTP Status {errorResponse.StatusCode} - {errorResponse.StatusDescription}");
                }
                else
                {
                    _logge.Error($"WebException: {webEx.Message}");
                }
            }
            catch (Exception ex)
            {
                // Captura qualquer outro tipo de erro
                _logge.Error($"Unhandled Exception: {ex.Message}");
            }
            finally
            {
                // Fecha stream mesmo em caso de falha
                stream?.Close();
            }

            if (buf == null)
            {
                _logge.Warn("Image could not be fetched. Returning default placeholder.");
                // Opcional: Retornar uma imagem padrão (placeholder)
                buf = GetPlaceholderImage();
            }

            return buf;
        }

        // Método para fornecer uma imagem padrão, se necessário
        private byte[] GetPlaceholderImage()
        {
            // Substitua pelo caminho real ou dados da imagem padrão
            return File.ReadAllBytes("path/to/placeholder/image.jpg");
        }



        public async Task<string> imgurUpload(string base64String)
        {
            return Base64ToWebPConverter.ConvertBase64ToWebP(base64String);
        }

        public async Task<bool> ArrumarImagensUsuario()
        {
            _logge.Debug($"ArrumarImagensUsuario");
            var response = await _repository.SelectAsync();
            if (response == null)
            {
                return false;
            }

            foreach (var listEntity in response)
            {

  
                //Aqui subimos tudo para servidor Imgur nossas imagens e temos o retorno da url

                if (!listEntity.ImagemLogin.Contains("imgur"))
                {
                    var convert64 = ImageToBase64(listEntity.ImagemLogin);

                    try
                    {
                        var UrlImagens = await imgurUpload(convert64);

                        if (UrlImagens.Contains("imgur"))
                        {
                            var model = _mapper.Map<UserEntity>(listEntity);
                            model.ImagemLogin = UrlImagens.ToString();
                            model.Password = listEntity.Password; //temporario por conta da requisiçao do google
                            model.Email = listEntity.Email; //temporario por conta da requisiçao do google
                            model.TokenRedes = listEntity.TokenRedes; //temporario por conta da requisiçao do google

        
                            _ = await _repository.UpdateAsync(model);
                            Thread.Sleep(1000);
                        }
                        else Thread.Sleep(80000);

                    }
                    catch { Thread.Sleep(80000); }
                }
               
     
            }

            return true;

        }


        public async Task<bool> ArrumarImagensUsuarioId(Guid id)
        {

   
            var response = await _repository.SelectAsync(id);
            _logge.Debug($"email: {response.Email}");
            if (response == null)
            {
                return false;
            }

                //Aqui subimos tudo para servidor Imgur nossas imagens e temos o retorno da url

                if (!response.ImagemLogin.Contains("imgur") && !response.ImagemLogin.Contains("webp"))
                {
                    var convert64 = ImageToBase64(response.ImagemLogin);

                    try
                    {
                        var UrlImagens = await imgurUpload(convert64);

                        if (UrlImagens.Contains("imgur") &&  response.ImagemLogin.Contains("webp"))
                        {
                            var model = _mapper.Map<UserEntity>(response);
                            model.ImagemLogin = UrlImagens.ToString();
                            model.Password = response.Password; //temporario por conta da requisiçao do google
                            model.Email = response.Email; //temporario por conta da requisiçao do google
                            model.TokenRedes = response.TokenRedes; //temporario por conta da requisiçao do google
                        
                            _ = await _repository.UpdateAsync(model);
                            Thread.Sleep(1000);
                        }
                        else Thread.Sleep(80000);

                    }
                    catch { Thread.Sleep(80000); }
                }         
            return true;

        }

        public async Task<bool> PutRecuperarSenha(string email)
        {
            try
            {
                _logge.Debug($"PutRecuperarSenha: {email}");
                var listEntity = await _iUserRepository.PutRecuperarSenha(email);

                if (listEntity == null || listEntity.Count() == 0)
                {
                    return false;
                }

                var listEntityUnic = listEntity.Where(p => p.Email == email).FirstOrDefault();

                Random rnd = new Random();
                int numeroAleatorio = rnd.Next(100000, 999999);

                string password = rnd.Next(100000, 999999).ToString();
                var TokenRedes = SaltCreate();
                var hash = Create(password, TokenRedes);
                listEntityUnic.Password = hash;

                var model = _mapper.Map<UserEntity>(listEntityUnic);        
                model.Password = listEntityUnic.Password; //temporario por conta da requisiçao do google
                model.TokenRedes = TokenRedes; //temporario por conta da requisiçao do google
                model.TrocarSenha = true;



                var result = await _repository.UpdateAsync(model);

                await _emailsNewsletterService.SendEmailPorTipoAsync(4, result.Email, result.Nome, password, null, result.Idioma);

                await _emailsNewsletterService.SendEmailReporte("<p> Olá, Recebemos uma solicitação de troca de senha para sua conta no site www.trocadesemente.com.br. Se você solicitou essa alteração, clique no link abaixo para redefinir sua senha: <b>" + password + " <b>  Se você não solicitou essa alteração, ignore esta mensagem e verifique se suas informações de login estão seguras.Atenciosamente, Equipe de suporte do site Troca de Semente</p>");
                return true;
                
            }
            catch (Exception ex)
            {
                _logge.Error($"error  : {ex}");
                _logge.Error($"error  : {ex.Message}");
                throw new Exception("Ocorreu um erro ao executar a operação. Detalhes: " + ex.Message);          
            }
          
        }


        public async Task<bool> PutSenhaRecuperada(string email, string senha)
        {
            try
            {
                _logge.Debug($"PutSenhaRecuperada: {email}");
                var listEntity = await _iUserRepository.PutRecuperarSenha(email);
                if (listEntity == null)
                {
                    return false;
                }

                var listEntityUnic = listEntity.Where(p => p.Email == email).FirstOrDefault();

                if (listEntity == null || listEntity.Count() > 0)
                {
                    Random rnd = new Random();

                    string password = senha;
                    var TokenRedes = SaltCreate();
                    var hash = Create(password, TokenRedes);

                    listEntityUnic.Password = hash;

                    var model = _mapper.Map<UserEntity>(listEntityUnic);
                    model.Password = listEntityUnic.Password; //temporario por conta da requisiçao do google
                    model.TokenRedes = TokenRedes; //temporario por conta da requisiçao do google
                    model.TrocarSenha = false;            
                    var result = await _repository.UpdateAsync(model);
                   // await _emailsNewsletterService.SendEmailPorTipoAsync(5, result.Email, result.Nome, password, null, result.Idioma);
                    //await _emailsNewsletterService.SendEmailReporte("Sua senha foi alterada com sucesso hoje:  " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "   Se você não solicitou essa alteração, entre no site e mude sua senha hoje mesmo. www.trocadesemente.com.br");
                }

                return false;
                
            }
            catch (Exception ex)
            {
                _logge.Error($"error  : {ex}");
                _logge.Error($"error  : {ex.Message}");
                throw new Exception("Ocorreu um erro ao executar a operação. Detalhes: " + ex.Message);
            }

        }

        public async Task<bool> DesativarEMail(string email)
        {
            _logge.Debug($"DesativarEMail: {email}");
            var listEntity = await _iUserRepository.PutRecuperarSenha(email);
            var model = _mapper.Map<UserEntity>(listEntity);
            model.EnviarEmail = false; //temporario por conta da requisiçao do google
            var result = await _repository.UpdateAsync(model);

            if (result.EnviarEmail == false)
            {
                return true;
            }
            return false;
        }

        private async void reportEmail() {
            try
            {
                var usuarios = await _iUserRepository.CountUser();
                var CountUserTermosResponsabilidadesInativos = await _iUserRepository.CountUserTermosResponsabilidadesInativos();
                var CountUserTermosResponsabilidadesAtivos = await _iUserRepository.CountUserTermosResponsabilidadesAtivos();
                var produtos = await _produtosRepositorio.SelectAsync();
                var mensagensP = await _mensagensRepository.SelectAsync();


                string emailBody = "Total Usuarios Cadastrados: " + usuarios
                    + " - Total de usuarios com termos de responsabilidades " + CountUserTermosResponsabilidadesAtivos
                    + " - Total usuarios sem termos de responsabilidades: " + CountUserTermosResponsabilidadesInativos
                    + " ------------------------------ Total Produtos disponivel: " + produtos.Where(p => p.Ativo == true && p.ClienteUsuarioId == new Guid("00000000-0000-0000-0000-000000000000")).Count()
                    + " ------------------------------ Total Produtos Finalizados: " + produtos.Where(p => p.Ativo == true && p.ClienteUsuarioId != new Guid("00000000-0000-0000-0000-000000000000")).Count()
                    + " ------------------------------ Total Produtos Mensagens: " + mensagensP.Count()
                    ;

                _logge.Debug($"emailBody : {emailBody}");
                //await _emailsNewsletterService.SendEmailReporte(emailBody);

                
            }
            catch (Exception ex)
            {
                _logge.Error($"Erro : {ex}");
            }
        }

        private bool TryParseBase64String(string base64String, out byte[] decodedBytes)
        {
            decodedBytes = null;
            try
            {
                decodedBytes = Convert.FromBase64String(base64String);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }

}

