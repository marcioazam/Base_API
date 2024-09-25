using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Fixture;

namespace Test.Infra
{
    public class DatabaseTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;

        public DatabaseTests(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ConnectionStringWithValue()
        {
            // Act
            string? connectionString = _fixture.GetConnectionString();

            // Assert
            Assert.True(string.IsNullOrEmpty(connectionString));
        }

        [Fact]
        public void DBContextIsNotNull()
        {
            // Act
            var context = _fixture.Context;

            // Assert
            Assert.NotNull(context);
        }
    }
}
