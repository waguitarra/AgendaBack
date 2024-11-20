using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.MensagensP;
using Api.Domain.Dtos.Protudos;
using Domain.Dtos.MensagensP;

namespace Api.Domain.Interfaces.Services.MensagensP
{
    public interface IMensagensPService
    {
        Task<MensagensPDto> Get(Guid Id);
        Task<IEnumerable<MensagensPDto>> GetAll(Guid UserId);
        Task<IEnumerable<MensagensPPorUnicoUsuarioDto>> GetAllMensagensPUnicoUsuario(Guid UserId , Guid myId);
        Task<IEnumerable<MensagensPPorUnicoUsuarioDto>> GetAllMensagensPGeneral(Guid UserId , int TipoServico);
        Task<IEnumerable<MensagensPDto>> GetCompleteByProdutos(Guid MensagemId);
        Task<int> GetCountMensagensUnico(Guid UserId, int TipoServico);
        Task<int> GetCountMensagensAll(Guid UserId);
        Task<MensagensPDtoCreateResult> Post(MensagensPDtoCreate Mensagem);
        Task<MensagensPDtoCreateResult> PostMensagensPrivadas(MensagensPDtoCreate Mensagem);
        Task<MensagensPDtoUpdateResult> Put(MensagensPDtoUpdate Mensagem);
        Task<MensagensPDtoUpdateResult> PostMensagensPLida(MensagensPDtoUpdate Mensagem);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<MensagensPPorUnicoUsuarioDto>> GetMensagensAllNoLida(Guid UserId);

        Task<ProdutosDto> GetAllMensagensPrivadasProduto(Guid UserId, Guid ClienteUsuario);


        Task<bool> GetAllBMensagensNaoLidas(Guid UserId);


    }
}
