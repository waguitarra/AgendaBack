using Api.Domain.Dtos.User;
using Api.Domain.Dtos.UserFornecedor;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.UseFornecedor;
using Api.Domain.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class UserFornecedorService : IUUserFornecedorService
    {

        private IRepository<UserFornecedorEntity> _repository;
        private readonly IMapper _mapper;
        private IUUserFornecedorRepository _iUserRepository;
        private IUFornecedorProdutosRepository _produtosRepositorio;

        public UserFornecedorService(IRepository<UserFornecedorEntity> repository
                        , IMapper mapper
                        , IUUserFornecedorRepository IUserRepository
                        , IUFornecedorProdutosRepository produtosRepositorio)
        {
            _repository = repository;
            _mapper = mapper;
            _iUserRepository = IUserRepository;
            _produtosRepositorio = produtosRepositorio;
        }

        public async Task<UserFornecedorDto> Get(Guid id)
        {
            var listEntity = await _repository.SelectAsync(id);

            if (listEntity != null)
            {
                listEntity = await _iUserRepository.GetProdutoPorUserId(id);

                foreach (var Produtos in listEntity.FornecedorProdutos)
                {
                    //await _produtosRepositorio.GetCompleteByMensagensP(Produtos.Id);
                    await _produtosRepositorio.GetCompleteByImagensF(Produtos.Id);
                    //await _produtosRepositorio.GetCompleteByCategoria(Produtos.CategoriaId);

                }

                return _mapper.Map<UserFornecedorDto>(listEntity);
            }
            return null;
        }
        public async Task<UserFornecedorDtoUpdateResult> DesativarUsuario(Guid id)
        {
            var listEntity = await _repository.SelectAsync(id);
            if (listEntity == null)
            {
                return null;
            }
            if (listEntity.Ativo == false)
            {
                listEntity.Ativo = true;
       
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
                    var entity = _mapper.Map<UserFornecedorEntity>(listEntity);
             

                    var result = await _repository.UpdateAsync(entity);
                    return _mapper.Map<UserFornecedorDtoUpdateResult>(result);
                }
            }
            return null;
        }
        public async Task<IEnumerable<UserFornecedorDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();

            foreach (var item in listEntity)
            {
                var users = await _iUserRepository.GetProdutoPorUserId(item.Id);

                foreach (var itemsProdutos in users.FornecedorProdutos)
                {
                   // await _produtosRepositorio.GetCompleteByMensagensF(itemsProdutos.Id);
                    await _produtosRepositorio.GetCompleteByImagensF(itemsProdutos.Id);
                    //await _produtosRepositorio.GetCompleteByCategoria(itemsProdutos.CategoriaId);
                }
            }

            return _mapper.Map<IEnumerable<UserFornecedorDto>>(listEntity);
        }
        public async Task<UserFornecedorDto> GetProdutoPorUserId(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserFornecedorDto>(entity);
        }
        public async Task<UserGetDadosBasicosDto> GetProdutoDadosPorUserId(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserGetDadosBasicosDto>(entity);
        }
        public async Task<UserFornecedorDtoCreateResult> Post(UserFornecedorDtoCreate user)
        {

            user.TokenRedes = SaltCreate();
            var hash = Create(user.Password, user.TokenRedes);
            user.Password = hash;
            var baseUser = await _iUserRepository.FindByEmail(user.Email);

            if (baseUser != null)
            {
                return null;
            }
            else
            {
                //var entity = _mapper.Map<UserFornecedorentity>(user);
                var entity = _mapper.Map<UserFornecedorEntity>(user);
                var result = await _repository.InsertAsync(entity);

                return _mapper.Map<UserFornecedorDtoCreateResult>(result);

            }
        }
        public async Task<UserFornecedorDtoUpdateResult> Put(UserFornecedorDtoUpdate user)
        {
            user.TokenRedes = SaltCreate();
            var hash = Create(user.Password, user.TokenRedes);
            user.Password = hash;
            var baseUser = await _iUserRepository.FindByEmail(user.Email);

            if (baseUser == null)
            {
                return null;
            }
            else
            {
                var entity = _mapper.Map<UserFornecedorEntity>(user);


                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<UserFornecedorDtoUpdateResult>(result);
            }
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        //Gerando Token aleatorio para validacao de usuario
        public static string SaltCreate()
        {
            byte[] randomBytes = new byte[256 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
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
      

    }

}

