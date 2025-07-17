using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PAW.Core.Extensions;
using PAW.Models;
using PAW.Models.ViewModels;
using PAW.Repositories;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;

namespace PAW.Business;

public interface IBusinessCatalog
{
    Task<IEnumerable<Catalog>> GetAllCatalogsAsync();
    Task<bool> SaveCatalogAsync(Catalog catalog);
    Task<bool> DeleteCatalogAsync(Catalog catalog);
    Task<Catalog> GetCatalogAsync(int id);
    Task<IEnumerable<CatalogViewModel>> Filter(Expression<Func<Catalog, bool>> predicate);
}

public class BusinessCatalog(IRepositoryCatalog repositoryCatalog) : IBusinessCatalog
{
    // Linq to Sql
    // Linq to Entities / Objects (dot notation)

    public async Task<IEnumerable<Catalog>> GetAllCatalogsAsync()
    {
        // Business Rules
        // revisar que sea entre las 7 am y 7 pm
        // tener permisos para leer en el usuario

        return await repositoryCatalog.ReadAsync();
    }

    public async Task<bool> SaveCatalogAsync(Catalog catalog)
    {
        var user = "";//Identity
        catalog.AddAudit(user);
        catalog.AddLogging(catalog.Identifier <= 0 ? Models.Enums.LoggingType.Create : Models.Enums.LoggingType.Update);

        return await repositoryCatalog.CheckBeforeSavingAsync(catalog);
    }

    public async Task<bool> DeleteCatalogAsync(Catalog catalog)
    {
        return await repositoryCatalog.DeleteAsync(catalog);
    }

    public async Task<Catalog> GetCatalogAsync(int id)
    {
        return await repositoryCatalog.FindAsync(id);
    }

    public async Task<IEnumerable<CatalogViewModel>> Filter(Expression<Func<Catalog, bool>> predicate)
    {
        return await repositoryCatalog.FilterAsync(predicate);
    }

}
