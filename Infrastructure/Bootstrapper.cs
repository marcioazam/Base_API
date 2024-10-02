using Domain.Commands.ClientesCommands;
using Domain.Commands.UsersCommands;
using Domain.Commands.ProdutosCommands;
using Domain.Commands.SuppliersCommands;
using Domain.Commands.TokensCommands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;
using Domain.ValueObjects.ResultInfo;
using Domain.Entities;
using Domain.Validators;
using Application.Interfaces.Services;
using Application.Interfaces.UoW;
using Application.Interfaces.Services.Security;
using Application.Interfaces.Factories;
using Application.Services;
using Application.Handlers.Bases;
using Application.Services.Security;
using Application.Factories;
using Infrastructure.Context;
using Infrastructure.Mappers;
using Infrastructure.Repositories;
using Infrastructure.UoW;

namespace Infrastructure
{
    public static class Bootstrapper
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            // Core
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DefaultContext>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IValidationFactory, ValidationFactory>();

            // Mappers
            services.RegisterMappings();

            // Token
            services.AddTransient<IRequestHandler<TokenInsertCommand, Result>, BaseInsertHandler<Token, TokenInsertCommand>>();
            services.AddTransient<IRequestHandler<TokenUpdateRevokedCommand, Result>, BaseUpdateHandler<Token, TokenUpdateRevokedCommand>>();
            services.AddTransient<IRepositoryBase<Token>, TokenRepository>();
            services.AddTransient<ITokenRepository, TokenRepository>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IValidator<Token>, TokenValidator>();

            // Client
            services.AddTransient<IRequestHandler<ClienteInsertCommand, Result>, BaseInsertHandler<Cliente, ClienteInsertCommand>>();
            services.AddTransient<IRequestHandler<ClienteUpdateCommand, Result>, BaseUpdateHandler<Cliente, ClienteUpdateCommand>>();
            services.AddTransient<IRequestHandler<ClienteDeleteCommand, Result>, BaseDeleteHandler<Cliente, ClienteDeleteCommand>>();
            services.AddTransient<IRepositoryBase<Cliente>, ClienteRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IValidator<Cliente>, ClienteValidator>();

            // User
            services.AddTransient<IRequestHandler<UserInsertCommand, Result>, BaseInsertHandler<User, UserInsertCommand>>();
            services.AddTransient<IRequestHandler<UserUpdateCommand, Result>, BaseUpdateHandler<User, UserUpdateCommand>>();
            services.AddTransient<IRequestHandler<UserDeleteCommand, Result>, BaseDeleteHandler<User, UserDeleteCommand>>();
            services.AddTransient<IRepositoryBase<User>, UserRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IValidator<User>, UserValidator>();

            // Supplier
            services.AddTransient<IRequestHandler<SupplierInsertCommand, Result>, BaseInsertHandler<Supplier, SupplierInsertCommand>>();
            services.AddTransient<IRequestHandler<SupplierUpdateCommand, Result>, BaseUpdateHandler<Supplier, SupplierUpdateCommand>>();
            services.AddTransient<IRequestHandler<SupplierDeleteCommand, Result>, BaseDeleteHandler<Supplier, SupplierDeleteCommand>>();
            services.AddTransient<IRepositoryBase<Supplier>, SupplierRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IValidator<Supplier>, SupplierValidator>();

            // Product
            services.AddTransient<IRequestHandler<ProdutoInsertCommand, Result>, BaseInsertHandler<Produto, ProdutoInsertCommand>>();
            services.AddTransient<IRepositoryBase<Produto>, ProdutoRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IValidator<Produto>, ProdutoValidator>();
        }
    }
}