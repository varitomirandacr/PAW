using Microsoft.AspNetCore.Mvc;
using PAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PAW.CatalogControllerTests
{
    public class CatalogControllerIntegrationTests
    {
        [Fact]
        public async Task GetAll_ReturnsCatalogs()
        {
            // Arrange
            var client = new HttpClient { BaseAddress = new Uri("http://127.0.0.1:3000/#/") };
            var response = await client.GetAsync("/");
            // Assert
            response.EnsureSuccessStatusCode();
            var catalogs = await response.Content.ReadAsStringAsync();
            Assert.NotNull(catalogs);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(catalogs);
        }
    }
}
