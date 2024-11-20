using Api.Domain.Dtos.CurtidasP;
using Api.Domain.Dtos.Protudos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.CuntidasP;
using Api.Domain.Interfaces.Services.Produtos;
using Api.Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class CurtidasPService : ICurtidasPService
    {
        IUCurtidasPRepository _repository;
        IUUserRepository _repositoryUser;
        IUProdutosRepository _repositoryProdutos;
        IProdutosService _produtoService;

        private IMapper _mapper;
        public CurtidasPService(IUCurtidasPRepository repository
            , IUProdutosRepository repositoryProdutos
            , IUUserRepository repositoryUser
            , IMapper mapper
            , IProdutosService produtoService)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryUser = repositoryUser;
            _repositoryProdutos = repositoryProdutos;
            _produtoService = produtoService;

        }

        public async Task<CurtidasPDto> Get(Guid Id)
        {
            var listEntity = await _repository.SelectAsync(Id);
            return _mapper.Map<CurtidasPDto>(listEntity);
        }

        public async Task<IEnumerable<CurtidasPDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            //foreach (var item in listEntity)
            //{
            //    await _repositoryUser.GetControleRigadoresPorUserId(item.UserId);
            //}
            return _mapper.Map<IEnumerable<CurtidasPDto>>(listEntity);
        }



        public async Task<ProdutosDto> Post(CurtidasPDtoCreate CurtidasP)
        {
            var curtidas = await _repository.SelectAsync();
            curtidas = curtidas.Where(p => p.UserId == CurtidasP.UserId && p.ProdutosId == CurtidasP.ProdutosId).ToList();
            var Produtos = await _produtoService.Get(CurtidasP.ProdutosId, null, 0 , 0, "");
            Produtos.CurtidasTotal = curtidas.Where(p => p.ProdutosId == CurtidasP.ProdutosId && p.Curtidas == true).ToList().Count();



            var listEntity = Produtos.CurtidasP.AsQueryable().Where(p => p.UserId == CurtidasP.UserId).ToList();
            //Caso nao existe nenhuma curtida desse usuario vamos criar uma nova curtida
            if (curtidas.Count() == 0)
            {
                var entity = _mapper.Map<CurtidasPEntity>(CurtidasP);
                entity.Curtidas = true;
        
                var result = await _repository.InsertAsync(entity);
                Produtos = await _produtoService.Get(CurtidasP.ProdutosId, null , 0, 0, "");

                var curtidasNovas = await _repository.SelectAsync();

                Produtos.CurtidasTotal = curtidasNovas.Where(p => p.ProdutosId == CurtidasP.ProdutosId && p.Curtidas == true).ToList().Count();

                return _mapper.Map<ProdutosDto>(Produtos);
            }
            else // Usuario ja tem uma curtida nesse produto.
            {
                if (listEntity[0].Curtidas == true)
                    listEntity[0].Curtidas = false;
                else
                    listEntity[0].Curtidas = true;

                var entityUpdate = _mapper.Map<CurtidasPEntity>(listEntity[0]);

                var resultUpdate = await _repository.UpdateAsync(entityUpdate);
                Produtos = await _produtoService.Get(CurtidasP.ProdutosId, null, 0, 0, "");

                var curtidasNovas = await _repository.SelectAsync();

                Produtos.CurtidasTotal = curtidasNovas.Where(p => p.ProdutosId == CurtidasP.ProdutosId && p.Curtidas == true).ToList().Count();
                return _mapper.Map<ProdutosDto>(Produtos);
            }
            
        }



        public async Task<ProdutosDto> Put(CurtidasPDtoUpdate CurtidasP)
        {
            var ProdutosId = await _repositoryProdutos.GetCompleteByCurtidasP(CurtidasP.ProdutosId);
            if (ProdutosId != null)
            {
                var entity = _mapper.Map<CurtidasPEntity>(CurtidasP);

                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<ProdutosDto>(result);
            }
            return null;
        }


        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<int> GetAllMyCurtidasTotal(Guid UserId)
        {
            return await _repository.GetAllMyCurtidasTotal(UserId);
        }
    }
}
