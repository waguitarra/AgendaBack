using Api.Domain.Interfaces.Services.Cliente;
using Data.Paginations;
using Domain.Dtos.Client;
using Domain.Helpers;
using Domain.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public IClientesService _service { get; set; }
        public ClienteController(IClientesService service)
        {
            _service = service;
        }


        //[Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] PaginationsDomain paginacao, string idioma)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await  _service.GetAll(idioma);            
                await HttpContext.InsertarParametrosPaginacaoEmResposta(result, paginacao.QuantidadePorPagina);
                return Ok (result.PaginarData(paginacao));
          
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //[Authorize("Bearer")]
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

        //[Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDto dtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(dtoCreate);

                if (result == null)
                {
                    return NotFound("Usuário não encontrado.");
                }

                if (result.Id != Guid.Empty)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Cliente já cadastrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro inesperado. Tente novamente mais tarde.");
            }
        }




        //[Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ClienteDto dtoUpdate)
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
    }

}
