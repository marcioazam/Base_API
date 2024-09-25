using Infrastructure.ExternalService.Generic;
using Infrastructure.Repositories;

namespace Test.Supplier.SMMOficialReserva
{
    public class ServicoTests
    {
        [Fact]
        public async Task GetListServiceWithSucess()
        {
            // Arrange
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://smmoficialreserva.net/api/v2?key=ad5f81176e9cdf24c12ef579e2c435e4&action=services");
            var myService = new GenericRequest(client);

            // Act
            //var services = await myService.GetListAsync<OfferedService>();

            // Assert
            //Assert.NotNull(services);
        }
    }
}