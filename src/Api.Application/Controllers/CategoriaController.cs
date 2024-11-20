using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Categorias;
using Api.Domain.Interfaces.Services.Categorias;
using Data.Paginations;
using Domain.Helpers;
using Domain.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public ICategoriasService _service { get; set; }
        public CategoriaController(ICategoriasService service)
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
        public async Task<ActionResult> Post([FromBody] CategoriaDtoCreate dtoCreate)
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
                    //return Created(new Uri(Url.Link("GetCategoriaWithId", new { id = result.Id })), result);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Categoria já cadastrada");
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //[Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CategoriaDtoUpdate dtoUpdate)
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
