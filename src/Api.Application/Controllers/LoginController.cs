using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Services;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto,
                                        [FromServices] ILoginService service,
                                        [FromServices] IConfiguration _configuration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (loginDto == null)
            {
                SendEmail email = new SendEmail(_configuration);
                _ = await email.EmailErros(loginDto.Email + " - Erro ao tentar fazer login" + "Erro: " + ModelState.ToString());     
                return BadRequest(ModelState);
            }

            try
            {
                var result = await service.FindByLogin(loginDto);
                if (result.ToString() != "Usuario não existe")
                {
      
                    SendEmail email = new SendEmail(_configuration);
                    _ = await email.UserLogado(loginDto.Email + ": " + result.ToString());
                    return result;
                }
                else
                {
                    SendEmail email = new SendEmail(_configuration);
                    _ = await email.EmailErros(loginDto.Email + " - Erro ao tentar fazer login");
                    return result;
                }
            }
            catch (ArgumentException e)
            {
                SendEmail email = new SendEmail(_configuration);
                _ = await email.EmailErros(e.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
