using Application.Interfaces.UoW;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UoW
{
    public class UnitOfWork(DefaultContext contexto) : IUnitOfWork
    {
        private readonly DefaultContext _contexto = contexto;

        public async Task<bool> Commit()
        {
            using var contextTransaction = _contexto.Database.BeginTransaction();

            try
            {
                int affectedRows = 0;

                affectedRows += await _contexto.SaveChangesAsync();

                contextTransaction.Commit();

                return affectedRows > 0;
            }
            catch (Exception)
            {
                contextTransaction.Rollback();

                throw;
            }
        }
    }
}
