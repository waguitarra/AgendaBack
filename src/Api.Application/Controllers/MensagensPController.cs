using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.MensagensP;
using Api.Domain.Interfaces.Services.MensagensP;
using Data.Paginations;
using Domain.Helpers;
using Domain.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MensagensPController : ControllerBase
    {
        public IMensagensPService _service { get; set; }

        public MensagensPController(IMensagensPService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll(Guid UserId, [FromQuery] PaginationsDomain paginacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetAll(UserId);
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
        [Route("GetAllMensagensPUnicoUsuario")]
        public async Task<ActionResult> GetAllMensagensPUnicoUsuario(Guid UserId, Guid MyId, [FromQuery] PaginationsDomain paginacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetAllMensagensPUnicoUsuario(UserId, MyId);

                if (result == null)
                {
                    return null;
                }
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
        [Route("GetAllMensagensPGeneral")]
        public async Task<ActionResult> GetAllMensagensPGeneral(Guid UserId, int tipoServico, [FromQuery] PaginationsDomain paginacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetAllMensagensPGeneral(UserId, tipoServico);

                if (result == null)
                {
                    return null;
                }
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
        [Route("GetMensagensAllNoLida")]
        public async Task<ActionResult> GetMensagensAllNoLida(Guid UserId, [FromQuery] PaginationsDomain paginacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetMensagensAllNoLida(UserId);

                if (result == null)
                {
                    return null;
                }
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
        [Route("GetCountMensagensUnico")]
        public async Task<ActionResult> GetCountMensagensUnico(Guid UserId, int tipoServico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetCountMensagensUnico(UserId, tipoServico);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Authorize("Bearer")]
        [HttpGet]
        [Route("GetCountMensagensAll")]
        public async Task<ActionResult> GetCountProdutoTipo(Guid UserId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetCountMensagensAll(UserId);
                return Ok(result);
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
        public async Task<ActionResult> Post([FromBody] MensagensPDtoCreate dtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(dtoCreate);
                if (result != null)
                {
                    //return Created(new Uri(Url.Link("GetMunicipioWithId", new { id = result.Id })), result);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Verifique todos os dados enviados porque algo está fora, ou os produtos ñ pertence aos clientes ou clintes e produtos ñ existe");
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        [Route("PostMensagensPrivadas")]
        public async Task<ActionResult> PostMensagensPrivadas([FromBody] MensagensPDtoCreate dtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.PostMensagensPrivadas(dtoCreate);
                if (result != null)
                {
                    //return Created(new Uri(Url.Link("GetMunicipioWithId", new { id = result.Id })), result);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Verifique todos os dados enviados porque algo está fora, ou os produtos ñ pertence aos clientes ou clintes e produtos ñ existe");
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        [Route("PutMensagensPLida")]
        public async Task<ActionResult> PostMensagensPLida(MensagensPDtoUpdate Produtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.PostMensagensPLida(Produtos);
                if (result != null)
                {
                    //return Created(new Uri(Url.Link("GetMunicipioWithId", new { id = result.Id })), result);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Id ñ existe");
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _service.Delete(id);
                return Ok(new { message = "deletado", Id = id });
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [Authorize("Bearer")]
        [HttpGet]
        [Route("GetAllMensagensPrivadasProduto")]
        public async Task<ActionResult> GetAllMensagensPrivadasProduto(Guid UserId, Guid ClienteUserId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetAllMensagensPrivadasProduto(UserId, ClienteUserId);                
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        //[Authorize("Bearer")]
        [HttpGet]
        [Route("GetAllBMensagensNaoLidas")]
        public async Task<ActionResult> GetAllBMensagensNaoLidas(Guid UserId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetAllBMensagensNaoLidas(UserId);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        
    }
}
