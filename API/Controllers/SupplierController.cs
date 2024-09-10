using API.Controllers.Extension;
using Application.DTOs.Entities.Supplier;
using Application.DTOs.Filters;
using Application.DTOs.Validation;
using Application.Factories;
using Application.Interfaces.Factories;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Commands.Base;
using Domain.Commands.Cliente;
using Domain.Commands.Supplier;
using Domain.Helpers;
using Domain.ValueObjects.ResultInfo;
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
            var result = await _supplierService.List<SupplierListDTO, SupplierFilterDTO>(filter);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _supplierService.GetById<SupplierListDTO>(id);

            return Ok(result);
        }

        [HttpGet("exist")]
        public async Task<IActionResult> Exist([FromQuery] SupplierFilterDTO filter)
        {
            var result = await _supplierService.Exist(filter);

            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count([FromQuery] SupplierFilterDTO filter)
        {
            var result = await _supplierService.Count(filter);

            return Ok(result);
        }

        [HttpGet("PagedList")]
        public async Task<IActionResult> PagedList([FromQuery] SupplierFilterDTO filter, int pageNumber, int pageSize)
        {
            var result = await _supplierService.PagedList<SupplierListDTO, SupplierFilterDTO>(filter, pageNumber, pageSize);

            return Ok(result);
        }
        
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Post(SupplierInsertCommand command)
        {
            var result = await _supplierService.Post(command);

            return ControllerExtension.BuildResult(this, result, ResponseStatus.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SupplierUpdateCommand command)
        {
            Result result = await _supplierService.Update(command);

            return ControllerExtension.BuildResult(this, result, ResponseStatus.NoContent);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(SupplierDeleteCommand command)
        {
            Result result = await _supplierService.Delete(command);

            return ControllerExtension.BuildResult(this, result, ResponseStatus.NoContent);
        }
    }
}