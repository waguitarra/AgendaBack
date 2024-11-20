using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Protudos;
using Api.Domain.Interfaces.Services.Produtos;
using Microsoft.Extensions.Configuration;
using Data.Paginations;
using Domain.Helpers;
using Domain.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        public IConfiguration _configuration { get; }
        public IProdutosService _service { get; set; }
        public ProdutosController(IProdutosService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }


        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll(Guid userId, [FromQuery] PaginationsDomain paginacao)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetAll(userId);

                if (result == null)
                {
                    return BadRequest("Id nao é valido");
                    SendEmail email = new SendEmail(_configuration);
                    _ = await email.EmailErros("Id é valido, userId:" + userId);
                }

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
        [HttpPost]
        [Route("PesquisaPorNomeMaxKm")]
        public async Task<ActionResult> PesquisaPorMaxKm(ProdutosDtoPesquisaCategoriasTipoServicos listaCategoriasServico, Guid userId)
        {
            PaginationsDomain paginacao = new PaginationsDomain();

            paginacao.Pagina = listaCategoriasServico.Pagina;
            paginacao.QuantidadePorPagina = listaCategoriasServico.QuantidadePorPagina;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.PesquisaPorNomeMaxKm(listaCategoriasServico, userId);

                if (result == null)
                {
                    return BadRequest("Id nao é valido");
                }

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
        [Route("{id}")]
        public async Task<ActionResult> Get(Guid id, Guid userId, double lat, double longi, string idioma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.Get(id, userId, lat, longi, idioma);

                if (result == null)
                {
                    return BadRequest("Id nao é valido");
                }

                return Ok(result);
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
        [Route("GetAllMensagensPrivadas")]
        public async Task<ActionResult> GetAllMensagensPrivadas(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetAllMensagensPrivadas(userId);

                if (result == null)
                {
                    return BadRequest("Id nao é valido");
                }

                return Ok(result);
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
        [Route("GetQtdProdutosFinalizados")]
        public async Task<ActionResult> GetQtdProdutosFinalizados(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetQtdProdutosFinalizados(userId);
                return Ok(result);
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
        [Route("{userId}/GetAllMyProduto")]
        public async Task<ActionResult> GetAllMyProduto(Guid userId, [FromQuery] PaginationsDomain paginacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetAllMyProduto(userId);

                if (result == null)
                {
                    return BadRequest("Id nao é valido");
                }

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
        [Route("GetAllAssuntosLivres")]
        public async Task<ActionResult> GetAllAssuntosLivres(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                var result = await _service.GetAllAssuntosLivres(userId);

                if (result == null)
                {
                    return BadRequest("Id nao é valido");
                }

                return Ok(result);
            }
            catch 
            {
                return BadRequest("Erro na consulta");
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutosDtoCreate dtoCreate)
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
        public async Task<ActionResult> Put([FromBody] ProdutosDtoUpdate dtoUpdate)
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
                SendEmail email = new SendEmail(_configuration);
                _ = await email.EmailErros(e.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }


        [Authorize("Bearer")]
        [HttpPut]
        [Route("PutClienteUsuarioId")]
        public async Task<ActionResult> PutClienteUsuarioId(Guid id, Guid clienteUsuarioId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.PutServiceClienteUsuarioId(id, clienteUsuarioId);
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
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.PutDeleteProduto(id);

                if (result == null)
                {
                    return BadRequest("Id nao é valido");
                }

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                SendEmail email = new SendEmail(_configuration);
                _ = await email.EmailErros(e.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost("{id}")]
        public async Task<ActionResult> EmailAllNewProduct(string idioma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.EmailAllNewProduct(idioma);

                if (result == null)
                {
                    return BadRequest("Id nao é valido");
                }

                return Ok(result);
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
