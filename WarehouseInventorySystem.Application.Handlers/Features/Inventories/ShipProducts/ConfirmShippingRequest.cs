namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ShipProducts;

public record ConfirmShippingRequest(
    string StorageCellId, 
    string ProductId, 
    int Quantity
);