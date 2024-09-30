using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Context.Tables;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class ClienteRepository(DefaultContext context, IMapper imapper) : BaseRepository<ClienteTable, Cliente>(context, imapper), IClienteRepository
    {
    }
}
