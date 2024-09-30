using MediatR;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Fixture;
using Test.Util;

namespace Test.API
{
    public class SupplierIntegrationTests : IClassFixture<DbContextFixture>
    {
        private readonly SupplierService _service;

        public SupplierIntegrationTests(DbContextFixture fixture)
        {
            //var repository = new ISupplierRepository(fixture.Context, fixture.Mapper);

            //var mediatorMock = new Mock<IMediator>();

            //_service = new SupplierService(mediatorMock.Object, repository);
        }

        //[Fact]
        //public void GetListSupplierSucess()
        //{
        //    // Arrange
        //    var list = _service.List().Result;

        //    // Assert
        //    AssertExtensions.NotNullOrEmpty(list);
        //}

        [Fact]
        public void GetSupplierByIdSucess()
        {
            //// Arrange
            //var list = _service.Get().Result;

            //// Assert
            //AssertExtensions.NotNullOrEmpty(list);
        }
    }
}
