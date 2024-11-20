using Api.Domain.Repository;
using AutoMapper;
using Domain.Dtos.EmailsNewsletter;
using Domain.Dtos.EnviarEmailDto;
using Domain.Entities;
using Domain.Interfaces.Services.EmailsNewsletter;
using Microsoft.Extensions.Configuration;
using NLog;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class EmailsNewsletterService : IEmailsNewsletterService
    {
        private IUEmailsNewsletterRepository _repository;
        private static readonly ILogger _logge = LogManager.GetCurrentClassLogger();
        public IConfiguration _configuration { get; }
        private readonly IMapper _mapper;

        public EmailsNewsletterService(
            IUEmailsNewsletterRepository repository
            , IMapper mapper
            , IConfiguration configuration
            )
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;

        }

        public async Task<EmailsNewsletterDto> Get(Guid Id)
        {
            var entity = await _repository.SelectAsync(Id);
            return _mapper.Map<EmailsNewsletterDto>(entity);
        }


        public async Task<IEnumerable<EmailsNewsletterDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<EmailsNewsletterDto>>(listEntity);
        }

        public async Task<EmailsNewsletterDtoCreateResult> Post(EmailsNewsletterDtoCreate EmailsNewslette)
        {
            var Newslette = await _repository.SelectAsync();
            var NewsletteAtiva = Newslette.Where(p => p.TipoNewsletter == EmailsNewslette.TipoNewsletter).FirstOrDefault();

            if (NewsletteAtiva == null)
            {
                var entity = _mapper.Map<EmailsNewsletterEntity>(EmailsNewslette);
                var result = await _repository.InsertAsync(entity);
                return _mapper.Map<EmailsNewsletterDtoCreateResult>(result);
            }

            return _mapper.Map<EmailsNewsletterDtoCreateResult>(null);

        }

        public async Task<EmailsNewsletterDtoUpdateResult> Put(EmailsNewsletterDtoUpdate EmailsNewslette)
        {  
            var entity = _mapper.Map<EmailsNewsletterEntity>(EmailsNewslette);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<EmailsNewsletterDtoUpdateResult>(result);
        }



        public async Task<bool> SendEmailAsync(EmailRequestDto mailRequest)
        {
            SendEmail email = new SendEmail(_configuration);
            return await email.SendEmailAsync(mailRequest);
        }

        public async Task<bool> SendEmailPorTipoAsync(int TipoEmailId, string email, string nome, string CodigoUsuario, string HtmlExpansao, string idioma)
        {
            _logge.Error($"TipoEmailId: {TipoEmailId} email {email} nome {nome} ");
            EmailsNewsletterDto getByTipoNewsletter = await GetByTipoNewsletter(TipoEmailId, idioma);

            var emailRequestDto = new EmailRequestDto 
            {
                ToEmail = email,
                Subject = getByTipoNewsletter.Nome,
                Body = getByTipoNewsletter.HTML,
                Nome = nome,
                CodigoUsuario = CodigoUsuario,
                HtmlExpansao = HtmlExpansao

            };

            var result = await SendEmailAsync(emailRequestDto);
            return result;
        }

        public async Task<EmailsNewsletterDto> GetByTipoNewsletter(int TipoNewsletter, string pais)
        {
            var result = await _repository.SelectAsync();
            return _mapper.Map<EmailsNewsletterDto>(result.Where(p => p.TipoNewsletter == TipoNewsletter && p.Pais == pais).FirstOrDefault());          
        }


        public async Task<bool> SendEmailReporte(string mailRequest)
        {
            SendEmail email = new SendEmail(_configuration);
            return await email.SendEmailReporte(mailRequest);        
        }

        public async Task<bool> EmailErros(string EmailReporte)
        {
            SendEmail email = new SendEmail(_configuration);
            return await email.EmailErros(EmailReporte);
        }
   
    }
}
