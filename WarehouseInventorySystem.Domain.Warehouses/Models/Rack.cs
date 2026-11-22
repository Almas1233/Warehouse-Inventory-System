namespace WarehouseInventorySystem.Domain.Warehouses.Models;

public class Rack
{
    public Guid Id { get; init; }

    public int Code { get; init; }

    public Guid WarehouseId { get; init; }
    public Warehouse Warehouse { get; init; }

    public List<StorageUnit> Cells { get; init; }
    
    public Rack( Guid warehouseId, Warehouse warehouse, List<StorageUnit> cells)
    {
        WarehouseId = warehouseId;
        Warehouse = warehouse;
        Cells = cells;
    }
}