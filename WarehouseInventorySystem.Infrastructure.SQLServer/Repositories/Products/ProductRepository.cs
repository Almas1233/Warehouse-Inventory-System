using Microsoft.EntityFrameworkCore;
using WarehouseInventorySystem.Infrastructure.Common.Base;
using WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Base;
using WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Context;
using WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Products.Models;
using WarehouseInventorySystem.Products.Models;

namespace WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Products;

public class ProductRepository
    : BaseRepository<Product, ProductEntity>,
        IProductRepository,
        IRepository
{
    public ProductRepository(
        WarehouseDbContext context,
        IEntityMapper<Product, ProductEntity> mapper)
        : base(context, mapper) {}
    
        public async Task<Product?> GetBySkuAsync(string sku)
        {
            var entity = await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Sku == sku);

            if (entity == null)
            {
                return null;
            }

            var result = Mapper.ToDomain(entity);

            return result;
    }
}