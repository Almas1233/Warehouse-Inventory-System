namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ReceiveStock.ConfirmReceiving;

public record ConfirmReceivingResponse(
    string ProductId, 
    string CellId, 
    int Quantity
);