using API.Controllers.Extension;
using API.Interfaces;
using Application.DTOs.Entities;
using Application.DTOs.Filters;
using Application.Factories;
using Application.Interfaces.Factories;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Commands.SuppliersCommands;
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
    public class SupplierController(ISupplierService supplierService, IMediator mediator) : ControllerExtension
        <SupplierInsertCommand, SupplierUpdateCommand, SupplierDeleteCommand, SupplierFilterDTO, SupplierListDTO, SupplierListDTO, Supplier>
        (mediator, supplierService)
    {

    }
}