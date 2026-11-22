namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ShippingStock.ReserveStock.ConfirmReserving;

public record ConfirmReservingResponse(
    string ProductId,
    string StorageCellId, 
    int Quantity
);