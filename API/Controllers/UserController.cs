using API.Controllers.Extension;
using Application.DTOs.Entities;
using Application.DTOs.Filters;
using Application.Interfaces.Services;
using Domain.Commands.UsersCommands;
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