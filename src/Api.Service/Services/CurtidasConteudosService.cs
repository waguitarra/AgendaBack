using Api.Domain.Dtos.CurtidasConteudosP;
using Api.Domain.Dtos.CurtidasP;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Categorias;
using Api.Domain.Interfaces.Services.CuntidasP;
using Api.Domain.Repository;
using AutoMapper;
using Domain.Dtos.Conteudo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class CurtidasConteudosService : ICurtidasConteudosService
    {
        IUCurtidasConteudosRepository _repository;
        IUUserRepository _repositoryUser;
        IUConteudosRepository _repositoryConteudos;
        IConteudosService _conteudosService;

        private IMapper _mapper;
        public CurtidasConteudosService(IUCurtidasConteudosRepository repository
            , IUConteudosRepository repositoryConteudos
            , IUUserRepository repositoryUser
            , IMapper mapper
            , IConteudosService conteudosService)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryUser = repositoryUser;
            _repositoryConteudos = repositoryConteudos;
            _conteudosService = conteudosService;

        }

        public async Task<CurtidasConteudosDto> Get(Guid Id)
        {
            var listEntity = await _repository.SelectAsync(Id);
            return _mapper.Map<CurtidasConteudosDto>(listEntity);
        }

        public async Task<IEnumerable<CurtidasConteudosDto>> GetAll(Guid ConteudosId)
        {
            var listEntity = await _repository.GetCompleteByCurtidasConteudos(ConteudosId);
            foreach (var item in listEntity)
            {
                await _repositoryUser.GetProdutoPorUserId(item.UserId);
            }
            return _mapper.Map<IEnumerable<CurtidasConteudosDto>>(listEntity);
        }



        public async Task<ConteudosDto> Post(CurtidasConteudosDtoCreate CurtidasConteudos)
        {
            var listEntity = await _repository.GetByCurtidasConteudosUserId(CurtidasConteudos.ConteudosId, CurtidasConteudos.UserId);
     
            var Conteudos = await _conteudosService.Get(CurtidasConteudos.ConteudosId, "pt");
           // Conteudos.TotalCurtidas = curtidas.Where(p => p.ConteudosId == CurtidasConteudos.ConteudosId && p.Curtidas == true).ToList().Count();




            //Caso nao existe nenhuma curtida desse usuario vamos criar uma nova curtida
            if (listEntity.Count() == 0)
            {
                var entity = _mapper.Map<CurtidasConteudosEntity>(CurtidasConteudos);
                entity.Curtidas = true;
           
                var result = await _repository.InsertAsync(entity);
                await _repositoryUser.SelectAsync(CurtidasConteudos.UserId);

                Conteudos = await _conteudosService.Get(CurtidasConteudos.ConteudosId, "pt");
      
                var curtidasNovas = await  _repository.GetCompleteByCurtidasConteudos(CurtidasConteudos.ConteudosId);
                foreach (var item in listEntity)
                {
                    await _repositoryUser.SelectAsync(item.UserId);
                }

                Conteudos.TotalCurtidas = curtidasNovas.Where(p => p.ConteudosId == CurtidasConteudos.ConteudosId && p.Curtidas == true).ToList().Count();

                return _mapper.Map<ConteudosDto>(Conteudos);
            }
            else // Usuario ja tem uma curtida nesse produto.
            {
                var entityUpdate = listEntity.ToList();

                if (entityUpdate[0].Curtidas == true)
                    entityUpdate[0].Curtidas = false;
                else
                    entityUpdate[0].Curtidas = true;

                var entity = _mapper.Map<CurtidasConteudosEntity>(entityUpdate[0]);
        
                var resultUpdate = await _repository.UpdateAsync(entity);


                var curtidasNovas = await _repository.GetCompleteByCurtidasConteudos(CurtidasConteudos.ConteudosId);

                var ListConteudosCurtidas = new List<CurtidasConteudosEntity>();

                foreach (var item in curtidasNovas)
                {
                    if (item.Curtidas == true)
                    {
                        item.User = await _repositoryUser.SelectAsync(item.UserId);
                        ListConteudosCurtidas.Add(item);
                    }

                }
                Conteudos.CurtidasConteudos = _mapper.Map<IEnumerable<CurtidasConteudosDto>>(ListConteudosCurtidas);
                Conteudos.TotalCurtidas = Conteudos.CurtidasConteudos.Count();
                var result = _mapper.Map<ConteudosDto>(Conteudos);
                return result;
            }   
      
        }



        public async Task<ConteudosDto> Put(CurtidasConteudosDtoUpdate CurtidasConteudos)
        {
            var ConteudosId = await _repositoryConteudos.SelectAsync(CurtidasConteudos.ConteudosId);
            if (ConteudosId != null)
            {
                var entity = _mapper.Map<CurtidasConteudosEntity>(CurtidasConteudos);
    
                var result = await _repository.UpdateAsync(entity);
                return _mapper.Map<ConteudosDto>(result);
            }
            return null;
        }


        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
