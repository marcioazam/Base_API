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

namespace Infrastructure
{
    public static class Bootstrapper
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            // Generics
            services.AddTransient<IValidationFactory, ValidationFactory>();
            services.AddTransient<IRequestHandler<BaseDeleteCommand, Result>, BaseDeleteHandler<Supplier, BaseDeleteCommand>>();
            services.AddTransient<IRequestHandler<BaseDeleteCommand, Result>, BaseDeleteHandler<Cliente, BaseDeleteCommand>>();

            // Handlers e Commands
            services.AddTransient<IRequestHandler<ClienteInsertCommand, Result>, BaseInsertHandler<Cliente, ClienteInsertCommand>>();
            services.AddTransient<IRequestHandler<ClienteUpdateCommand, Result>, BaseUpdateHandler<Cliente, ClienteUpdateCommand>>();
            services.AddTransient<IRequestHandler<SupplierInsertCommand, Result>, BaseInsertHandler<Supplier, SupplierInsertCommand>>();
            services.AddTransient<IRequestHandler<SupplierUpdateCommand, Result>, BaseUpdateHandler<Supplier, SupplierUpdateCommand>>();

            // Repositories
            services.AddTransient<IRepositoryBase<Cliente>, ClienteRepository>();
            services.AddTransient<IRepositoryBase<Supplier>, SupplierRepository>();

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();

            // Services
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ISupplierService, SupplierService>();

            // Validators
            services.AddTransient<IValidator<Cliente>, ClienteValidator>();
            services.AddTransient<IValidator<Supplier>, SupplierValidator>();

            // Factories

            // Others
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DefaultContext>();

            services.RegisterMappings();
        }
    }
}
