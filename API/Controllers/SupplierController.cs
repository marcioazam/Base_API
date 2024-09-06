using Application.DTOs.Supplier;
using Application.DTOs.Validation;
using Application.Factories;
using Application.Interfaces.Factories;
using Application.Interfaces.Services;
using Domain.Commands.Supplier;
using Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController(ISupplierService supplierService) : ControllerBase
    {
        private readonly ISupplierService _supplierService = supplierService;

        [HttpGet("ListAll")]
        public async Task<IActionResult> List()
        {
            SupplierListDTO dTO = new SupplierListDTO(null, "string");

            var resultado = await _supplierService.List<SupplierListDTO>(dTO);

            return Ok(resultado);
        }

        //[HttpGet]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var resultado = await _supplierService.Get<SupplierListDTO>(x => x.Id == id);

        //    return Ok(resultado);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Exist(int id)
        //{
        //    var resultado = await _supplierService.Exist<SupplierListDTO>(x => x.Id == id);

        //    return Ok(resultado);
        //}

        [HttpGet("count")]
        public async Task<IActionResult> Count(int id)
        {
            var resultado = await _supplierService.Count<SupplierListDTO>(null);

            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> PagedList(string nome, int pageNumber, int pageSize)
        {
            var resultado = await _supplierService.PagedList<SupplierListDTO>(x => x.Nome.Contains(nome), pageNumber, pageSize);

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SupplierInsertCommand command)
        {
            var resultado = await _supplierService.Post(command);

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