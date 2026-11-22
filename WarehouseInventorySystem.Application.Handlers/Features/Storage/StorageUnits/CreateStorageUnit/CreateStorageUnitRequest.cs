namespace WarehouseInventorySystem.Application.Handlers.Features.Storage.StorageUnits.CreateStorageUnit;

public record CreateStorageUnitRequest(
    string RackId, 
    int Length, 
    int Width, 
    int Height
    );