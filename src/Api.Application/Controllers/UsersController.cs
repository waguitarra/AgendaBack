using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Data.Paginations;
using Domain.Helpers;
using Domain.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Services;

namespace Api.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IConfiguration _configuration { get; }
        public IUserService _service { get; set; }

        public UsersController(IUserService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }


        //[Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] PaginationsDomain paginacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetAll();
                await HttpContext.InsertarParametrosPaginacaoEmResposta(result, paginacao.QuantidadePorPagina);
                return Ok(result.PaginarData(paginacao));
            }
            catch (ArgumentException e)
            {
                SendEmail email = new SendEmail(_configuration);
                _ = await email.EmailErros(e.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Get(id);
                if (result == null)
                {
                    return BadRequest("Id nao é valido");
                }

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDtoCreate user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest("Email Já casdastrado ou está vazio");
                }
            }
            catch (ArgumentException e)
            {
                SendEmail email = new SendEmail(_configuration);
                _ = await email.EmailErros(e.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDtoUpdate user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Put(user);
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
                SendEmail email = new SendEmail(_configuration);
                _ = await email.EmailErros(e.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        

        [Authorize("Bearer")]
        [HttpPut]
        [Route("/api/Users/UpdateLatitudeLongitudeModuloEscuro")]
        public async Task<ActionResult> PutLatitudeLongitude([FromBody] UserLatLogDtoUpdate userLatLogDtoUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.PutLatitudeLongitude(userLatLogDtoUpdate);
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
                SendEmail email = new SendEmail(_configuration);
                _ = await email.EmailErros(e.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Authorize("Bearer")]
        [HttpGet]
        [Route("{userId}/DesativarUsuario")]
        public async Task<ActionResult> DesativarUsuario(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.DesativarUsuario(userId);
                if (result != null)
                {
                    if (result.Ativo)
                        return Ok("Usuario Ativo com sucesso");
                    else
                        return Ok("Usuario Desativado com sucesso");
                }
                else
                {
                    return BadRequest("Não existe referencia com Id mencionado");
                }
            }
            catch (ArgumentException e)
            {
                SendEmail email = new SendEmail(_configuration);
                _ = await email.EmailErros(e.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        //[Authorize("Bearer")]
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        await _service.Delete(id);
        //        return Ok(new { message = "deletado", Id = id });
        //    }
        //    catch (ArgumentException e)
        //    {
        //        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
        //    }
        //}



        [Authorize("Bearer")]
        [HttpPost]
        [Route("/api/Users/ArrumarImagensUsuario")]
        public async Task<ActionResult> ArrumarImagensUsuario()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _service.ArrumarImagensUsuario();
                return Ok(new { message = "Imanges Imgur Ok"});
            }
            catch (ArgumentException e)
            {
                SendEmail email = new SendEmail(_configuration);
                _ = await email.EmailErros(e.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }




        //[Authorize("Bearer")]
        [HttpPut]
        [Route("/api/Users/PutRecuperarSenha")]
        public async Task<ActionResult> PutRecuperarSenha(string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.PutRecuperarSenha(email));
        }


        //[Authorize("Bearer")]
        [HttpPut]
        [Route("/api/Users/PutSenhaRecuperada")]
        public async Task<ActionResult> PutSenhaRecuperada(string email, string senha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.PutSenhaRecuperada(email, senha));
        }


        [HttpPut]
        [Route("/api/Users/DesativarEMail")]
        public async Task<ActionResult> DesativarEMail(string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.DesativarEMail(email));
        }

        


    }
}
