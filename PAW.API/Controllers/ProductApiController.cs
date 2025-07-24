using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;
using PAW.Models.PAWModels;
using PAW.Models.ViewModels;

namespace PAW.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductApiController(IBusinessProduct businessProduct) : Controller
{
    [HttpGet(Name = "GetProducts")]
    public async Task<IEnumerable<Product>> GetAll()
    {
        return await businessProduct.GetAllProductsAsync();
    }

    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var Product = await businessProduct.GetProductAsync(id);
        return Product;
    }

    [HttpPost("filter", Name = "FilterProducts")]
    public async Task<IEnumerable<ProductViewModel>> Filter(ConditionViewModel condition)
    {
        var predicate = ConditionResolver<Product>.ResolveCondition(condition.Criteria, condition.Property, condition.Value, condition.Start, condition.End);
        var results = await businessProduct.Filter(predicate);
        return results;
    }

    [HttpPost]
    public async Task<bool> Save([FromBody] IEnumerable<Product> Products)
    {
        foreach (var item in Products)
        {
            await businessProduct.SaveProductAsync(item);
        }
        return true;
    }

    [HttpDelete]
    public async Task<bool> Delete(Product Product)
    {
        return await businessProduct.DeleteProductAsync(Product);
    }
}

