namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ShippingStock.ReserveStock.ConfirmReserving;

public record ConfirmReservingRequest(
    string Sku,
    string StorageCellId,
    int Quantity
);