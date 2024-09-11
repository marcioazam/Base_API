using API.Controllers.Extension;
using Application.DTOs.Entities.Supplier;
using Application.DTOs.Filters;
using Application.DTOs.Validation;
using Application.Factories;
using Application.Interfaces.Factories;
using Application.Interfaces.Services;
using Domain.Commands.Base;
using Domain.Commands.Cliente;
using Domain.Helpers;
using Domain.ValueObjects.ResultInfo;
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
            var result = await _ClienteService.List<ClienteListDTO, ClienteFilterDTO>(filter);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _ClienteService.GetById<ClienteListDTO>(id);

            return Ok(result);
        }

        [HttpGet("exist")]
        public async Task<IActionResult> Exist([FromQuery] ClienteFilterDTO filter)
        {
            var result = await _ClienteService.Exist<ClienteFilterDTO>(filter);

            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count([FromQuery] ClienteFilterDTO filter)
        {
            var result = await _ClienteService.Count<ClienteFilterDTO>(filter);

            return Ok(result);
        }

        [HttpGet("PagedList")]
        public async Task<IActionResult> PagedList([FromQuery] ClienteFilterDTO filter, int pageNumber, int pageSize)
        {
            var result = await _ClienteService.PagedList<ClienteListDTO, ClienteFilterDTO>(filter, pageNumber, pageSize);

            return Ok(result);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(ClienteInsertCommand command)
        //{
        //    var result = await _ClienteService.Post(command);

        //    return ControllerExtension.BuildResult(this, result, ResponseStatus.Created);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update(ClienteUpdateCommand command)
        //{
        //    Result result = await _ClienteService.Update(command);

        //    return ControllerExtension.BuildResult(this, result, ResponseStatus.NoContent);
        //}

        //[HttpDelete]
        //public async Task<IActionResult> Delete(ClienteDeleteCommand command)
        //{
        //    Result result = await _ClienteService.Delete(command);

        //    return ControllerExtension.BuildResult(this, result, ResponseStatus.NoContent);
        //} 
    }
}