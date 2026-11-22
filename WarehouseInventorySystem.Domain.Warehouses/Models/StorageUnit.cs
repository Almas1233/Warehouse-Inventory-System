using WarehouseInventorySystem.Domain.Common.Base;

namespace WarehouseInventorySystem.Domain.Warehouses.Models;

public class StorageUnit : BaseDomainModel
{
    public StorageUnit( 
        int code,
        int length, 
        int width, 
        int height,
        Guid rackId
    ) 
    {
        Code = code;
        Length = length;
        Width = width;
        Height = height;
        RackId = rackId;
    }
    
    public int Code { get; init; }

    public int Length { get; init; }
    public int Width { get; init; }
    public int Height { get; init; }

    public Guid RackId { get; init; }

    public bool ProductCapacity(
        int length, 
        int width, 
        int height
    )
    {
        if (length > Length &&
            width > Width &&
            height > Height)
        {
            return false;
        }

        return true;
    }
}