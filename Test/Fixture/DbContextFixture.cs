using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.Fixture
{
    public class DbContextFixture : IDisposable
    {
        public IMapper Mapper { get; private set; }

        public DbContextFixture()
        {
            // Carregar o appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            // Configurar os serviços
            var services = new ServiceCollection();

            // Adicionar AutoMapper ao serviço
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var serviceProvider = services.BuildServiceProvider();

            // Inicializar o Mapper
            Mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public string? GetConnectionString()
        {
            // Carregar o appsettings.json e pegar a ConnectionString
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration.GetConnectionString("DefaultConnection");
        }

        public void Dispose()
        {
            // Limpeza de recursos
         
        }
    }
}
