using WarehouseInventorySystem.Infrastructure.Common.Base;
using WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Products.Models;
using WarehouseInventorySystem.Products.Models;

namespace WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Products.Mapper;

public class ProductMapper 
    : IEntityMapper<Product, ProductEntity>
{
    public Product ToDomain(ProductEntity entity)
    {
        return new Product(
            entity.Name,
            entity.Sku,
            entity.Length,
            entity.Width,
            entity.Height)
        {
            Id = entity.Id,
        };
    }

    public ProductEntity ToEntity(Product product)
    {
        return new ProductEntity(
            product.Name,
            product.Sku,
            product.Length,
            product.Width,
            product.Height
        )
        {
            Id = product.Id,
        };
    }
}