using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos.EmailsNewsletter;
using Domain.Dtos.EnviarEmailDto;

namespace Domain.Interfaces.Services.EmailsNewsletter
{
    public interface IEmailsNewsletterService
    {
        Task<EmailsNewsletterDto> Get(Guid Id);
        Task<IEnumerable<EmailsNewsletterDto>> GetAll();
        Task<EmailsNewsletterDtoCreateResult> Post(EmailsNewsletterDtoCreate EmailsNewsletter);
        Task<EmailsNewsletterDtoUpdateResult> Put(EmailsNewsletterDtoUpdate EmailsNewsletter);
        Task<bool> SendEmailAsync(EmailRequestDto EmailRequest);
        Task<bool> SendEmailPorTipoAsync(int TipoEmailId, string Email, string nome, string CodigoUsuario, string Expansao, string idioma);
        Task<EmailsNewsletterDto> GetByTipoNewsletter(int TipoNewsletter, string idioma);

        Task<bool> SendEmailReporte(string EmailReporte);

        Task<bool> EmailErros(string EmailReporte);
    }
}
