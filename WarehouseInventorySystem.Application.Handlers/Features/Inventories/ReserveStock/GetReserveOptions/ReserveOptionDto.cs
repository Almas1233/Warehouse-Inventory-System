namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ShippingStock.ReserveStock.GetReserveOptions;

public record ReserveOptionDto(
    string StorageCellId,
    string WarehouseName,
    string RackCode,
    int CellCode,
    int AvailableQuantity
);