using Microsoft.EntityFrameworkCore;
using WarehouseInventorySystem.Domain.Common.Base;
using WarehouseInventorySystem.Infrastructure.Common.Base;
using WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Context;

namespace WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Base;

public class BaseRepository<TDomain, TEntity>
    : IBaseRepository<TDomain, TEntity>
    where TDomain : BaseDomainModel
    where TEntity : BaseEntity
{
    protected readonly WarehouseDbContext DbContext;
    protected readonly DbSet<TEntity> DbSet;
    protected readonly IEntityMapper<TDomain, TEntity> Mapper;

    public BaseRepository(
        WarehouseDbContext context, 
        IEntityMapper<TDomain, TEntity> mapper
    )
    {
        DbContext = context;
        DbSet = context.Set<TEntity>();
        Mapper = mapper;
    }

    public async Task<TDomain?> GetByIdAsync(Guid id)
    {
        var entity = await DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            return null;
        }

        var result = Mapper.ToDomain(entity);

        return result;
    }

    public async Task <int> AddAsync(TDomain domain)
    {
        var entity = Mapper.ToEntity(domain);

        await DbSet.AddAsync(entity);
        
        return await  DbContext.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        var result = await DbContext.SaveChangesAsync();
        
        return result;
    }
}