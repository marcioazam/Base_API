using API.Controllers.Extension;
using API.Interfaces;
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
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController(ISupplierService supplierService, IMediator mediator) : 
        ControllerExtension<SupplierInsertCommand>(mediator)
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
    }
}