namespace WarehouseInventorySystem.Domain.Common.Exceptions;

public enum ResponseCode
{
    //InventoryBalance
    InventoryBalanceQuantityBelowZero = 1,
    AvailableQuantityBelowThanQuantity = 2,
    
    //Product
    ProductSizeBelowZero = 33
}