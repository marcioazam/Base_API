using Application.DTOs.Entities.Supplier;
using Application.DTOs.Filters;
using Application.DTOs.Validation;
using Application.Factories;
using Application.Interfaces.Factories;
using Application.Interfaces.Services;
using Domain.Commands.Supplier;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController(ISupplierService supplierService) : ControllerBase
    {
        private readonly ISupplierService _supplierService = supplierService;

        [HttpGet("List")]
        public async Task<IActionResult> List([FromQuery]SupplierFilterDTO filter)
        {
            var resultado = await _supplierService.List<SupplierListDTO, SupplierFilterDTO>(filter);

            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var resultado = await _supplierService.GetById<SupplierListDTO>(id);

            return Ok(resultado);
        }

        [HttpGet("exist")]
        public async Task<IActionResult> Exist([FromQuery] SupplierFilterDTO filter)
        {
            var resultado = await _supplierService.Exist<SupplierFilterDTO>(filter);

            return Ok(resultado);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count([FromQuery] SupplierFilterDTO filter)
        {
            var resultado = await _supplierService.Count<SupplierFilterDTO>(filter);

            return Ok(resultado);
        }

        [HttpGet("PagedList")]
        public async Task<IActionResult> PagedList([FromQuery] SupplierFilterDTO filter, int pageNumber, int pageSize)
        {
            var resultado = await _supplierService.PagedList<SupplierListDTO, SupplierFilterDTO>(filter, pageNumber, pageSize);

            return Ok(resultado);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(SupplierInsertCommand command)
        {
            var resultado = await _supplierService.Post(command);

            return BuildActionResult(resultado);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SupplierUpdateCommand command)
        {
            var resultado = await _supplierService.Update(command);

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