using Infrastructure.Context.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class DefaultContext(DbContextOptions<DefaultContext> options) : DbContext(options)
    {
        public DbSet<SupplierTable> Supplier { get; set; }

        public DbSet<ClienteTable> Cliente { get; set; }

        public DbSet<UserTable> User { get; set; }

        public DbSet<TokenTable> Token { get; set; }

        public DbSet<ProdutoTable> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer();
        }
    }
}
