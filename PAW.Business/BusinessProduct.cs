using PAW.Core.Extensions;
using PAW.Models;
using PAW.Models.ViewModels;
using PAW.Repositories;
using System.Linq.Expressions;

namespace PAW.Business;

public interface IBusinessProduct
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<bool> SaveProductAsync(Product Product);
    Task<bool> DeleteProductAsync(Product Product);
    Task<Product> GetProductAsync(int id);
    Task<IEnumerable<ProductViewModel>> Filter(Expression<Func<Product, bool>> predicate);
}

public class BusinessProduct(IRepositoryProduct repositoryProduct) : IBusinessProduct
{
    // Linq to Sql
    // Linq to Entities / Objects (dot notation)

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        // Business Rules
        // revisar que sea entre las 7 am y 7 pm
        // tener permisos para leer en el usuario

        return await repositoryProduct.ReadAsync();
    }

    public async Task<bool> SaveProductAsync(Product Product)
    {
        var user = "";//Identity
        Product.AddAudit(user);
        Product.AddLogging(Product.ProductId <= 0 ? Models.Enums.LoggingType.Create : Models.Enums.LoggingType.Update);

        return await repositoryProduct.CheckBeforeSavingAsync(Product);
    }

    public async Task<bool> DeleteProductAsync(Product Product)
    {
        return await repositoryProduct.DeleteAsync(Product);
    }

    public async Task<Product> GetProductAsync(int id)
    {
        return await repositoryProduct.FindAsync(id);
    }

    public async Task<IEnumerable<ProductViewModel>> Filter(Expression<Func<Product, bool>> predicate)
    {
        return await repositoryProduct.FilterAsync(predicate);
    }

}
