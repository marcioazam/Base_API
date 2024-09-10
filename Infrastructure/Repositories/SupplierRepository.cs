using Application.Services;
using AutoMapper;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Infrastructure.Context.Tables;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class SupplierRepository(DefaultContext context, IMapper imapper) : BaseRepository<SupplierTable, Supplier>(context, imapper), ISupplierRepository
    {
    }
}
