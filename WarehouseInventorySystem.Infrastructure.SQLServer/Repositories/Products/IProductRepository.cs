using WarehouseInventorySystem.Infrastructure.Common.Base;
using WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Products.Models;
using WarehouseInventorySystem.Products.Models;

namespace WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Products;

public interface IProductRepository
    : IBaseRepository<Product, ProductEntity>
{
    Task<Product?> GetBySkuAsync(string sku);
}