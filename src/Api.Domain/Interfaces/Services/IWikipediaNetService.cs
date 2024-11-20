using System;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Interfaces.Services
{
    public interface IWikipediaNetService
    {
        Task<WikipediaDto> Gettexto(String texto);
    }

}
