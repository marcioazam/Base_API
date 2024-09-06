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
            services.AddTransient<IGenericRepository<Supplier>, SupplierRepository>();

            services.AddTransient<IRequestHandler<SupplierInsertCommand, CommandResult>, BaseInsertHandler<Supplier, SupplierInsertCommand>>();

            //services.AddTransient<IRequestHandler<AtualizarProdutoCommand, CommandResult>, AtualizarProdutoHandler>();
            //services.AddTransient<IRequestHandler<ExcluirProdutoCommand, CommandResult>, ExcluirProdutoHandler>();



            services.AddTransient<ISupplierRepository, SupplierRepository>();

            services.AddTransient<ISupplierService, SupplierService>();

            services.AddTransient<IValidator<Supplier>, SupplierValidator>();

            services.AddTransient<IValidationFactory, ValidationFactory>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<DefaultContext>();

            services.RegisterMappings();
        }
    }
}
