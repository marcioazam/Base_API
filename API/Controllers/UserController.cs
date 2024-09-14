using API.Controllers.Extension;
using Application.DTOs.Entities;
using Application.DTOs.Entities.Supplier;
using Application.DTOs.Filters;
using Application.Interfaces.Services;
using Domain.Commands.User;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService UserService, IMediator mediator) : ControllerExtension
        <UserInsertCommand, UserUpdateCommand, UserDeleteCommand, UserFilterDTO, UserListDTO, UserListDTO, User>
        (mediator, UserService)
{
}