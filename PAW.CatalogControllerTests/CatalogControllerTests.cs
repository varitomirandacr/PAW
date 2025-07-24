using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PAW.API.Controllers;
using PAW.Business;
using PAW.Models;
using Xunit;

public class CatalogControllerTests
{
    private readonly Mock<IBusinessCatalog> _mockBusinessCatalog;
    private readonly CatalogApiController _controller;

    public CatalogControllerTests()
    {
        _mockBusinessCatalog = new Mock<IBusinessCatalog>();
        _controller = new CatalogApiController(_mockBusinessCatalog.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsCatalogs()
    {
        // Arrange
        var catalogs = new List<Catalog>
        {
            new Catalog { Identifier = 1, Name = "Test1" },
            new Catalog { Identifier = 2, Name = "Test2" }
        };
        _mockBusinessCatalog.Setup(b => b.GetAllCatalogsAsync()).ReturnsAsync(catalogs);

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result,
            item => Assert.Equal("Test1", item.Name),
            item => Assert.Equal("Test2", item.Name));
    }

    [Fact]
    public async Task GetById_ReturnsCatalog()
    {
        // Arrange
        var catalog = new Catalog { Identifier = 1, Name = "Test" };
        _mockBusinessCatalog.Setup(b => b.GetCatalogAsync(1)).ReturnsAsync(catalog);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        Assert.Equal(catalog, result.Value);
    }

    [Fact]
    public async Task Save_CallsSaveCatalogAsyncForEachItem()
    {
        // Arrange
        var catalogs = new List<Catalog>
        {
            new Catalog { Identifier = 1, Name = "Test1" },
            new Catalog { Identifier = 2, Name = "Test2" }
        };
        _mockBusinessCatalog.Setup(b => b.SaveCatalogAsync(It.IsAny<Catalog>())).ReturnsAsync(true);

        // Act
        var result = await _controller.Save(catalogs);

        // Assert
        Assert.True(result);
        _mockBusinessCatalog.Verify(b => b.SaveCatalogAsync(It.IsAny<Catalog>()), Times.Exactly(2));
    }

    [Fact]
    public async Task Delete_CallsDeleteCatalogAsync()
    {
        // Arrange
        var catalog = new Catalog { Identifier = 1, Name = "Test" };
        _mockBusinessCatalog.Setup(b => b.DeleteCatalogAsync(catalog)).ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(catalog);

        // Assert
        Assert.True(result);
        _mockBusinessCatalog.Verify(b => b.DeleteCatalogAsync(catalog), Times.Once);
    }
}
