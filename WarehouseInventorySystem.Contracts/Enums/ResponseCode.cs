namespace WarehouseInventorySystem.Contracts.Enums;

public enum ResponseCode
{
    // Products: 10xxx
    ProductNotFound = 10001,
    ProductAlreadyExists = 10002,
    InvalidProductData = 10003,
    ProductSizeBelowZero = 10004,

    // Receiving: 20xxx
    ReceivingNotFound = 20001,
    ReceivingAlreadyCompleted = 20002,
    InvalidReceivingData = 20003,

    // Shipping: 30xxx
    ShippingNotFound = 30001,
    ShippingAlreadyCompleted = 30002,
    InsufficientStock = 30003,

    // Inventory: 40xxx
    InventoryItemNotFound = 40001, 
    InsufficientInventory = 40002, // Недостаточно доступного остатка
    InventoryBalanceNotFound = 40003,
    InventoryBalanceQuantityBelowZero = 40004,
    AvailableQuantityBelowThanQuantity = 40005,
    
    // Warehouse
    WarehouseNotFound = 50001,
    WarehouseAlreadyExists = 50002,
    RackNotFound = 50003,
    RackAlreadyExists = 50004,
    StorageCellNotFound = 50005,
    StorageCellAlreadyExists = 50006,
    
    InvalidInput = 60001
    
}