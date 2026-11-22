namespace WarehouseInventorySystem.Domain.Common.Base;

public class BaseDomainModel
{
    public Guid Id { get; init; }

    public BaseDomainModel(Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
    }
}