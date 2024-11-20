using System;
using System.Net;
using System.Threading.Tasks;
using Data.Paginations;
using Domain.Dtos.EmailsNewsletter;
using Domain.Dtos.EnviarEmailDto;
using Domain.Helpers;
using Domain.Interfaces.Services.EmailsNewsletter;
using Domain.Paginations;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsNewsletterController : ControllerBase
    {

        public IEmailsNewsletterService _service { get; set; }
        public EmailsNewsletterController(IEmailsNewsletterService service)
        {
            _service = service;
        }


        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await  _service.GetAll();
                return Ok (result);
          
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmailsNewsletterDtoCreate dtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(dtoCreate);
                if (result != null && result.Id != new Guid("00000000-0000-0000-0000-000000000000"))
                {
                    //return Created(new Uri(Url.Link("GetEmailsNewsletterWithId", new { id = result.Id })), result);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("TipoNewsletter: " + dtoCreate.TipoNewsletter +  " já existe");
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EmailsNewsletterDtoUpdate dtoUpdate)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(dtoUpdate);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Não existe referencia com Id mencionado");
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
        
        [Authorize("Bearer")]
        [HttpPost("send")]
        public async Task<ActionResult> SendMail([FromForm] EmailRequestDto request)
        {
            try
            {
                return Ok(await _service.SendEmailAsync(request));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost("SendMailPorTipo")]
        public async Task<ActionResult> SendMailPorTipo([FromForm] int TipoNewsletter, [FromForm] string Email, [FromForm] string Nome, [FromForm] string CodigoUsuario, [FromForm] string HtmlExpansao, string idioma)
        {
            try
            {                
                return Ok(await _service.SendEmailPorTipoAsync(TipoNewsletter, Email, Nome, CodigoUsuario, HtmlExpansao, idioma));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost("GetByTipoNewsletter")]
        public async Task<ActionResult> GetByTipoNewsletter([FromForm] int TipoNewsletter, string idioma)
        {
            try
            {
                var result = await _service.GetByTipoNewsletter(TipoNewsletter, idioma);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost("EmailErros")]
        public async Task<ActionResult> EmailErros([FromForm] string Email)
        {
            try
            {
                var result = await _service.EmailErros(Email);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
                
    }

}
