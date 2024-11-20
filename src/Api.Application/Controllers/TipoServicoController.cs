using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.TipoServico;
using Data.Paginations;
using Domain.Helpers;
using Domain.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicoController : ControllerBase
    {
        public ITipoServicoService _service { get; set; }
        public TipoServicoController(ITipoServicoService service)
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
                var result = await _service.GetAll(idioma);
                await HttpContext.InsertarParametrosPaginacaoEmResposta(result, paginacao.QuantidadePorPagina);
                return Ok(result.PaginarData(paginacao));
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
                //return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
                return BadRequest(ModelState);
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



    }

}
