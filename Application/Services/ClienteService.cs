using Domain.Interfaces.Entities.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Application.Interfaces.Services;
using Application.Services.Base;

namespace Application.Services
{
    public class ClienteService(IClienteRepository repository) : ServiceBase<IClienteRepository, Cliente>(repository), IClienteService
    {
    }
}
