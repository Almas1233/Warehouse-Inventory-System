namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ShipProducts;

public record ConfirmShippingResponse(
    string ProductId,
    string StorageCellId, 
    int Quantity
);