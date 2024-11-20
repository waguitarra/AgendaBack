using System;
using System.Buffers.Text;
using System.Threading.Tasks;
using Domain.Dtos.NsfwSpyP;

namespace Domain.Interfaces.Services.NsfwSpy
{
    public interface INsfwSpyPServico
    {
        Task<NsfwSpyPDto> GetBase64(String imagem);
    }
}
