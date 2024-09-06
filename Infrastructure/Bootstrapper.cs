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

namespace Infrastructure
{
    public static class Bootstrapper
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            // Generics
            services.AddTransient<IGenericRepository<Supplier>, SupplierRepository>();
            services.AddTransient<IValidationFactory, ValidationFactory>();

            // Handlers e Commands
            services.AddTransient<IRequestHandler<SupplierInsertCommand, CommandResult>, BaseInsertHandler<Supplier, SupplierInsertCommand>>();
            services.AddTransient<IRequestHandler<SupplierUpdateCommand, CommandResult>, BaseUpdateHandler<Supplier, SupplierUpdateCommand>>();
            //services.AddTransient<IRequestHandler<ExcluirProdutoCommand, CommandResult>, ExcluirProdutoHandler>();

            // Repositories
            services.AddTransient<ISupplierRepository, SupplierRepository>();

            // Services
            services.AddTransient<ISupplierService, SupplierService>();

            // Validators
            services.AddTransient<IValidator<Supplier>, SupplierValidator>();

            // Factories

            // Others
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DefaultContext>();

            services.RegisterMappings();
        }
    }
}
