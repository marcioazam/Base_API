using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Mappers;

namespace Test.Fixture
{
    public class DbContextFixture : IDisposable
    {
        public DefaultContext Context { get; private set; }
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

            services.AddDbContext<DefaultContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            var serviceProvider = services.BuildServiceProvider();

            // Obter o contexto configurado
            Context = serviceProvider.GetRequiredService<DefaultContext>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                // Escaneia o assembly atual para todos os profiles e os adiciona
                //cfg.AddMaps(Assembly.GetExecutingAssembly());

                // Se os profiles estiverem em outro assembly, você pode especificar assim:
                cfg.AddMaps(typeof(ProfileBase).Assembly);
            });

            Mapper = mapperConfig.CreateMapper();
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
            Context.Dispose();
        }
    }
}
