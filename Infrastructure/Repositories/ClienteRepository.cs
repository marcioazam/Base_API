using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context.Tables;
using Infrastructure.Context;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClienteRepository(DefaultContext context, IMapper imapper) : RepositoryBase<ClienteTable, Cliente>(context, imapper), IClienteRepository
    {
    }
}
