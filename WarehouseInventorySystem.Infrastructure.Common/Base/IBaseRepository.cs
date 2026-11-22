using WarehouseInventorySystem.Domain.Common.Base;

namespace WarehouseInventorySystem.Infrastructure.Common.Base;

public interface IBaseRepository <TDomain, TEntity>
where TDomain : BaseDomainModel
where TEntity : BaseEntity
{
    Task<TDomain?> GetByIdAsync(Guid id);
    Task <int> AddAsync(TDomain domain);
    Task <int> SaveChangesAsync();
}