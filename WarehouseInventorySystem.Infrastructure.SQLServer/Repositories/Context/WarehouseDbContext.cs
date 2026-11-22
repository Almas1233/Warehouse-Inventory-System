using Microsoft.EntityFrameworkCore;
using WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Products.Models;

namespace WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Context;

public class WarehouseDbContext : DbContext
{
    public DbSet<ProductEntity> Products { get; set; }
    
    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
        : base(options)
    {
    }
}