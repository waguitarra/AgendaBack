using Api.Domain.Interfaces.Services.DenunciaProdutoUsuario;
using Api.Domain.Interfaces.Services.Denuncias;
using Api.Domain.Interfaces.Services.Produtos;
using Api.Domain.Interfaces.Services.User;
using AutoMapper;
using Domain.Dtos.DenunciaProdutoUsuario;
using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DenunciaProdutoUsuarioService : IDenunciaProdutoUsuarioService
    {
        private IUDenunciaProdutoUsuarioRepository _repository;
        private IUserService _usuarioRepository;
        private IProdutosService _produtoRepository;
        private IDenunciasService _denunciasRepository;

        private readonly IMapper _mapper;

        public DenunciaProdutoUsuarioService(IUDenunciaProdutoUsuarioRepository repository
                                            , IMapper mapper
                                            , IUserService usuarioRepository
                                            , IProdutosService produtoRepository
                                            , IDenunciasService denunciasRepository
                                            )
        {
            _repository = repository;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _produtoRepository = produtoRepository;
            _denunciasRepository = denunciasRepository;
        }

        public async Task<DenunciaProdutoUsuarioDto> Get(Guid Id)
        {
            var entity = await _repository.SelectAsync(Id);
            await _usuarioRepository.Get(entity.UserId);
            await _produtoRepository.Get(entity.ProdutosId, null, 0, 0, "");
            await _denunciasRepository.Get(entity.DenunciasId);

            return _mapper.Map<DenunciaProdutoUsuarioDto>(entity);
        }

        public async Task<IEnumerable<DenunciaProdutoUsuarioDto>> GetAll()
        {

            var listEntity = await _repository.SelectAsync();
            foreach (var item in listEntity)
            {
                await _usuarioRepository.Get(item.UserId);
                await _produtoRepository.Get(item.ProdutosId, null, 0, 0, "");
                await _denunciasRepository.Get(item.DenunciasId);

            }
            return _mapper.Map<IEnumerable<DenunciaProdutoUsuarioDto>>(listEntity);
        }

        public async Task<DenunciaProdutoUsuarioDtoCreateResult> Post(DenunciaProdutoUsuarioDtoCreate DenunciaProdutoUsuario)
        {
            try
            {
                var model = _mapper.Map<DenunciaProdutoUsuarioEntity>(DenunciaProdutoUsuario);

                var result = await _repository.InsertAsync(model);
                return _mapper.Map<DenunciaProdutoUsuarioDtoCreateResult>(result);
            }
            catch (Exception)
            {

                return null;
            }

        }

        public async Task<DenunciaProdutoUsuarioDtoUpdateResult> Put(DenunciaProdutoUsuarioDtoUpdate DenunciaProdutoUsuario)
        {
            var model = _mapper.Map<DenunciaProdutoUsuarioEntity>(DenunciaProdutoUsuario);

            var result = await _repository.UpdateAsync(model);
            return _mapper.Map<DenunciaProdutoUsuarioDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DenunciaProdutoUsuarioDto>> GetUserProduto(Guid UserId, Guid ProdutoId)
        {
            var listEntity = await _repository.SelectAsync();
            listEntity.Select(p => p.UserId == UserId && p.ProdutosId == ProdutoId).ToList();
            return _mapper.Map<IEnumerable<DenunciaProdutoUsuarioDto>>(listEntity);
        }

    }
}
