using Domain.Models.Base;
using Domain.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TModel> : IGenericRepository<TModel>
        where TModel : class, IEntity
    {
        
    }
}
