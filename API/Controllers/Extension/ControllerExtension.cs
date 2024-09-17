using API.Helpers;
using API.Interfaces;
using Application.DTOs.Filters;
using Application.Interfaces.DTOs;
using Application.Interfaces.Filters;
using Application.Interfaces.Services;
using Application.Interfaces.Services.Base;
using Application.Services;
using Domain.EnumTypes;
using Domain.Helpers;
using Domain.Interfaces.Command.Base;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.ValueObjects;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Extension
{
    public class ControllerExtension<TInsertCommand, TUpdateCommand, TDeleteCommand, TFilter, TEntityListDTO, TEntityPagedListDTO, TEntity>(IMediator mediator, IServiceBase service) : ControllerBase
        where TInsertCommand : IRequest<Result>, IBaseInsertCommand<TEntity>
        where TUpdateCommand : IRequest<Result>, IBaseUpdateCommand
        where TDeleteCommand : IRequest<Result>, IBaseDeleteCommand
        where TFilter : IFilter
        where TEntityListDTO : IEntityDTO
        where TEntityPagedListDTO : IEntityDTO
        where TEntity : class, IEntity
    {
        private readonly IMediator _mediator = mediator;
        private readonly IServiceBase _service = service;

        [HttpPost]
        public virtual async Task<IActionResult> Post(TInsertCommand command)
        {
            return await MediatorSend(command, ResponseStatus.Created);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(TUpdateCommand command)
        {
            return await MediatorSend(command, ResponseStatus.NoContent);
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete(TDeleteCommand command)
        {
            return await MediatorSend(command, ResponseStatus.NoContent);
        }

        [HttpGet("List")]
        public virtual async Task<IActionResult> List([FromQuery] TFilter filter)
        {
            return ResponseHelper.BuildResult(this, await _service.List<TEntityListDTO, TFilter>(filter), ResponseStatus.Ok);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get(long id)
        {
            return ResponseHelper.BuildResult(this, await _service.GetById<TEntity>(id), ResponseStatus.Ok);
        }

        [HttpGet("exist")]
        public virtual async Task<IActionResult> Exist([FromQuery] TFilter filter)
        {
            return ResponseHelper.BuildResult(this, await _service.Exist(filter), ResponseStatus.Ok);
        }

        [HttpGet("count")]
        public virtual async Task<IActionResult> Count([FromQuery] TFilter filter)
        {
            return ResponseHelper.BuildResult(this, await _service.Count(filter), ResponseStatus.Ok);
        }

        [HttpGet("PagedList")]
        public virtual async Task<IActionResult> PagedList([FromQuery] TFilter filter, int pageNumber = 1, int pageSize = 10)
        {
            return ResponseHelper.BuildResult(this, await _service.PagedList<TEntityPagedListDTO, TFilter>(filter, pageNumber, pageSize), ResponseStatus.Ok);
        }

        [NonAction]
        public async Task<IActionResult> MediatorSend<TCommand>(TCommand command, ResponseStatus responseStatus) where TCommand : IRequest<Result>
        {
            Result result = await _mediator.Send(command);

            return ResponseHelper.BuildResult(this, result, responseStatus);
        }       
    }
}
