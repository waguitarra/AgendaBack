using Api.Domain.Dtos.Denuncias;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Denuncias;
using Api.Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class DenunciaService : IDenunciasService
    {
        private IUDenunciasRepository _repository;

        private readonly IMapper _mapper;

        public DenunciaService(IUDenunciasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DenunciasDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<DenunciasDto>(entity);
        }

        public async Task<IEnumerable<DenunciasDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<DenunciasDto>>(listEntity);
        }

        public async Task<DenunciasDtoCreateResult> Post(DenunciasDtoCreate Denuncias)
        {
            var entity = _mapper.Map<DenunciasEntity>(Denuncias);

            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<DenunciasDtoCreateResult>(result);
        }

        public async Task<DenunciasDtoUpdateResult> Put(DenunciasDtoUpdate Denuncias)
        {
            var entity = _mapper.Map<DenunciasEntity>(Denuncias);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<DenunciasDtoUpdateResult>(result);   
        }


        public async Task<bool> Delete(Guid id)
        {
            var Denuncias = await _repository.SelectAsync(id);

            if (Denuncias != null)
            {
                var entity = _mapper.Map<DenunciasEntity>(Denuncias);

                var result = _repository.UpdateAsync(entity);
                return true;
            }
            return false;
        }

    }
}
