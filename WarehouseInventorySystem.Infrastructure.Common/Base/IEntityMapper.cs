using WarehouseInventorySystem.Domain.Common.Base;

namespace WarehouseInventorySystem.Infrastructure.Common.Base;

public interface IEntityMapper<TDomain, TEntity>
where TDomain : BaseDomainModel
where TEntity : BaseEntity
{
    TDomain ToDomain(TEntity entity);
    TEntity ToEntity(TDomain domain);
}