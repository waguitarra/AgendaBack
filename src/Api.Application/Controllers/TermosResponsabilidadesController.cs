using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.TermosResponsabilidades;
using Domain.Interfaces.Services.TermosResponsabilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermosResponsabilidadesController : ControllerBase
    {
        public ITermosResponsabilidadesService _service { get; set; }
        public TermosResponsabilidadesController(ITermosResponsabilidadesService service)
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
        public async Task<ActionResult> Post([FromBody] TermosResponsabilidadesDtoCreate dtoCreate)
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
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Termo de responsabilidade já cadastrada");
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] TermosResponsabilidadesDtoUpdate dtoUpdate)
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
