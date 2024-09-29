using API.Controllers.Extension;
using Application.DTOs.Entities;
using Application.DTOs.Filters;
using Application.Interfaces.Services;
using Domain.Commands.ClientesCommands;
using Domain.Commands.ProdutosCommands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController(IProdutoService ClienteService, IMediator mediator) : ControllerExtension
         <ProdutoInsertCommand, ClienteUpdateCommand, ClienteDeleteCommand, ProdutoFilterDTO, ProdutoListDTO, ProdutoListDTO, Produto>
         (mediator, ClienteService)
    {
    }
}
