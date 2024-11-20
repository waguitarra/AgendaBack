using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.TipoServico;
using Api.Domain.Interfaces.Services.TipoServico;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class TipoServicoService : ITipoServicoService
    {

        private IUTipoServicoRepository _repository;
        private IMapper _mapper;


        public TipoServicoService(IUTipoServicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoServicoDto>> GetAll(string idioma)
        {
            var listEntity = await _repository.SelectAsync();
            listEntity = listEntity.Where(p => p.Pais == idioma).ToList();
            return _mapper.Map<IEnumerable<TipoServicoDto>>(listEntity);
        }

        public async Task<TipoServicoDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<TipoServicoDto>(entity);
        }
    }
}
