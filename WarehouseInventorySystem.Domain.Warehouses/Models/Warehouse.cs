namespace WarehouseInventorySystem.Domain.Warehouses.Models;

public class Warehouse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    
    public List<Rack> Racks { get; init; }
    
    public Warehouse(
        string name, 
        List<Rack> racks
    )
    {
        Name = name;
        Racks = racks;
    }
    
    
}