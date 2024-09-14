using Application.Interfaces.Services;
using Application.Interfaces.UoW;
using Application.Services;
using Domain.Commands.Base;
using Domain.Commands.Supplier;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;
using Infrastructure.Context;
using Infrastructure.Mappers;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using Infrastructure.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Handlers.Bases;
using Application.Factories;
using FluentValidation;
using Application.Interfaces.Factories;
using Domain.Validators;
using Domain.Entities;
using Domain.Commands.Cliente;
using Domain.ValueObjects.ResultInfo;
using Domain.Commands.User;
using Application.Services.Auth;
using Application.Interfaces.Services.Auth;

namespace Infrastructure
{
    public static class Bootstrapper
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            // Handlers e Commands
            services.AddTransient<IRequestHandler<ClienteInsertCommand, Result>, BaseInsertHandler<Cliente, ClienteInsertCommand>>();
            services.AddTransient<IRequestHandler<ClienteUpdateCommand, Result>, BaseUpdateHandler<Cliente, ClienteUpdateCommand>>();
            services.AddTransient<IRequestHandler<ClienteDeleteCommand, Result>, BaseDeleteHandler<Cliente, ClienteDeleteCommand>>();
            
            services.AddTransient<IRequestHandler<SupplierInsertCommand, Result>, BaseInsertHandler<Supplier, SupplierInsertCommand>>();
            services.AddTransient<IRequestHandler<SupplierUpdateCommand, Result>, BaseUpdateHandler<Supplier, SupplierUpdateCommand>>();
            services.AddTransient<IRequestHandler<SupplierDeleteCommand, Result>, BaseDeleteHandler<Supplier, SupplierDeleteCommand>>();

            services.AddTransient<IRequestHandler<UserInsertCommand, Result>, BaseInsertHandler<User, UserInsertCommand>>();
            services.AddTransient<IRequestHandler<UserUpdateCommand, Result>, BaseUpdateHandler<User, UserUpdateCommand>>();
            services.AddTransient<IRequestHandler<UserDeleteCommand, Result>, BaseDeleteHandler<User, UserDeleteCommand>>();

            // Repositories
            services.AddTransient<IRepositoryBase<Cliente>, ClienteRepository>();
            services.AddTransient<IRepositoryBase<Supplier>, SupplierRepository>();
            services.AddTransient<IRepositoryBase<User>, UserRepository>();

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // Services
            services.AddTransient<IAuthService, AuthService>();

            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IUserService, UserService>();

            // Validators
            services.AddTransient<IValidator<Cliente>, ClienteValidator>();
            services.AddTransient<IValidator<Supplier>, SupplierValidator>();
            services.AddTransient<IValidator<User>, UserValidator>();

            // Factories
            services.AddTransient<IValidationFactory, ValidationFactory>();

            // Others
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DefaultContext>();

            services.RegisterMappings();
        }
    }
}
