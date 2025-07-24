using Microsoft.EntityFrameworkCore;
using PAW.Models;
using PAW.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Repositories;

public interface IRepositoryProduct
{
    Task<bool> UpsertAsync(Product entity, bool isUpdating);
    Task<bool> CreateAsync(Product entity);
    Task<bool> DeleteAsync(Product entity);
    Task<IEnumerable<Product>> ReadAsync();
    Task<Product> FindAsync(int id);
    Task<bool> UpdateAsync(Product entity);
    Task<bool> UpdateManyAsync(IEnumerable<Product> entities);
    Task<bool> ExistsAsync(Product entity);
    Task<bool> CheckBeforeSavingAsync(Product entity);
    Task<IEnumerable<ProductViewModel>> FilterAsync(Expression<Func<Product, bool>> predicate);
}

public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
{
    public async Task<bool> CheckBeforeSavingAsync(Product entity)
    {
        var exists = await ExistsAsync(entity);
        if (exists)
        {
            // algo mas 
        }

        return await UpsertAsync(entity, exists);
    }

    //x => x.Rating > 3.5M && x.Rating <= 5M;
    public async Task<IEnumerable<ProductViewModel>> FilterAsync(Expression<Func<Product, bool>> predicate)
    {
        var random = new Random();
        /*var items = from c in DbContext.Catalogs
            where c.Rating > 3.5M && c.Rating <= 5M
            select new
            {
                c.TempID,
                c.Name,
                c.Description,
                c.Rating,
                Test = "Test Property"
            };*/

        /*return from c in DbContext.Catalogs
               where c.Rating > 3.5M && c.Rating <= 5M
               select c;*/

        return await DbContext.Products.Where(predicate)
            .Select(x => new ProductViewModel
            {
                ProductId= x.ProductId,
                ProductName = x.ProductName,
                Description = x.Description,
                Rating = x.Rating,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                TempID = random.Next(1, 1000) // Simulating a temporary ID for the view model
            }).ToListAsync();
    }

    public async new Task<bool> ExistsAsync(Product entity) 
    {
        return await DbContext.Products.AnyAsync(x => x.ProductId == entity.ProductId);
    }
}
