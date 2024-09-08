using Application.DTOs.Entities.Supplier;
using Application.DTOs.Filters;
using Application.DTOs.Validation;
using Application.Factories;
using Application.Interfaces.Factories;
using Application.Interfaces.Services;
using Domain.Commands.Base;
using Domain.Commands.Cliente;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController(IClienteService ClienteService) : ControllerBase
    {
        private readonly IClienteService _ClienteService = ClienteService;

        [HttpGet("List")]
        public async Task<IActionResult> List([FromQuery] ClienteFilterDTO filter)
        {
            var resultado = await _ClienteService.List<ClienteListDTO, ClienteFilterDTO>(filter);

            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var resultado = await _ClienteService.GetById<ClienteListDTO>(id);

            return Ok(resultado);
        }

        [HttpGet("exist")]
        public async Task<IActionResult> Exist([FromQuery] ClienteFilterDTO filter)
        {
            var resultado = await _ClienteService.Exist<ClienteFilterDTO>(filter);

            return Ok(resultado);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count([FromQuery] ClienteFilterDTO filter)
        {
            var resultado = await _ClienteService.Count<ClienteFilterDTO>(filter);

            return Ok(resultado);
        }

        [HttpGet("PagedList")]
        public async Task<IActionResult> PagedList([FromQuery] ClienteFilterDTO filter, int pageNumber, int pageSize)
        {
            var resultado = await _ClienteService.PagedList<ClienteListDTO, ClienteFilterDTO>(filter, pageNumber, pageSize);

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteInsertCommand command)
        {
            var resultado = await _ClienteService.Post(command);

            return BuildActionResult(resultado);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClienteUpdateCommand command)
        {
            var resultado = await _ClienteService.Update(command);

            return BuildActionResult(resultado);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(BaseDeleteCommand command)
        {
            var resultado = await _ClienteService.Delete(command);

            return BuildActionResult(resultado);
        }

        private IActionResult BuildActionResult(Domain.Commands.Base.CommandResult resultado)
        {
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.Erros);
            }

            return CreatedAtAction("Get", new { id = resultado.Id }, resultado.Id);
        }
    }
}