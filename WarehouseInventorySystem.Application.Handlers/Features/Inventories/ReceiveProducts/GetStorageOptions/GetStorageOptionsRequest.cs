namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ReceiveStock.GetStorageOptions;

public record GetStorageOptionsRequest(
    string Sku, 
    int Unit
);