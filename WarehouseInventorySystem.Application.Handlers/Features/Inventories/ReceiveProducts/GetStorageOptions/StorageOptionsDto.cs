namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ReceiveStock.GetStorageOptions;

public record StorageOptionsDto(
    string StorageCellId,
    string WarehouseName,
    string RackCode,
    int CellCode,
    int AvailableQuantity
);