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
    public class SupplierService(ISupplierRepository repository) : ServiceBase<ISupplierRepository, Supplier>(repository), ISupplierService
    {
    }
}
