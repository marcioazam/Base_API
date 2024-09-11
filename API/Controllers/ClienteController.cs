using API.Controllers.Extension;
using Application.DTOs.Entities.Supplier;
using Application.DTOs.Filters;
using Application.DTOs.Validation;
using Application.Factories;
using Application.Interfaces.Factories;
using Application.Interfaces.Services;
using Domain.Commands.Base;
using Domain.Commands.Cliente;
using Domain.Commands.Supplier;
using Domain.Entities;
using Domain.Helpers;
using Domain.ValueObjects.ResultInfo;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController(IClienteService ClienteService, IMediator mediator) : ControllerExtension
        <ClienteInsertCommand, ClienteUpdateCommand, ClienteDeleteCommand, ClienteFilterDTO, ClienteListDTO, ClienteListDTO, Cliente>
        (mediator, ClienteService)
    {
    }
}