namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ReceiveStock.ConfirmReceiving;

public record ConfirmReceivingRequest(
    string StorageCellId, 
    string Sku, 
    int Quantity
);