namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ShippingStock.ReserveStock.GetReserveOptions;

public record GetReserveOptionsRequest(
    string Sku, 
    int Unit
);