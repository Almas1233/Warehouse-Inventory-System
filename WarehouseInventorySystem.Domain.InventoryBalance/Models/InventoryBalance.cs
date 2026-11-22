using InventoryBalances.Exceptions;
using WarehouseInventorySystem.Contracts.Enums;
using WarehouseInventorySystem.Domain.Common.Base;
using WarehouseInventorySystem.Domain.Common.Exceptions;
using ResponseCode = WarehouseInventorySystem.Contracts.Enums.ResponseCode;

namespace InventoryBalances.Models;

public class InventoryBalance : BaseDomainModel
{
    public Guid ProductId { get; private set; }
    public Guid StorageCellId { get; private set; }

    public int Quantity { get; private set; }
    public int ReservedQuantity { get; private set; }

    public int AvailableQuantity { get; private set; }

    public InventoryBalance(
        Guid productId,
        Guid storageCellId,
        int quantity
    ) 
    {
        ProductId = productId;
        StorageCellId = storageCellId;
        Quantity = quantity;
    }
    
    public static InventoryBalance Create(
        Guid productId,
        Guid storageCellId,
        int quantity) 
    {
        if (quantity <= 0)
        {
            throw new DomainInventoryBalanceValidationException(
                "Quantity must be greater than 0.",
                ResponseCode.InventoryBalanceQuantityBelowZero,
                "Invalid validation. Quantity below zero",
                400
                    );
        }
        
        return new InventoryBalance(
            productId,
            storageCellId,
            quantity
        );
    }
    
    public void AddQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new DomainInventoryBalanceValidationException(
                "Quantity must be greater than 0.",
                ResponseCode.InventoryBalanceQuantityBelowZero,
                "Invalid validation. Quantity below zero.",
                400
                );
        }

        Quantity += quantity;
        AvailableQuantity += quantity;
    }

    public void RemoveQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new DomainInventoryBalanceValidationException(
                "Quantity must be greater than 0.",
                ResponseCode.InventoryBalanceQuantityBelowZero,
                "Invalid validation. Quantity below zero.",
                400
            );
        }

        if (AvailableQuantity < quantity)
        {
            throw new DomainInventoryBalanceValidationException(
                "Cannot remove quantity from inventory balance.", 
                ResponseCode.InsufficientInventory,
                "Insufficient available stock. Quantity more than available",
                400
            );
        }

        Quantity -= quantity;
        AvailableQuantity -= quantity;
    }

    public void Reserve(int quantity)
    {
        if (quantity <= 0)
        {
            throw new BaseDomainException(
                "Quantity must be greater than 0.",
                ResponseCode.InventoryBalanceQuantityBelowZero,
                "Invalid validation. Quantity below zero.",
                400
            );
        }

        if (AvailableQuantity < quantity)
        {
            throw new BaseDomainException(
                "Cannot remove quantity from inventory balance.", 
                ResponseCode.InsufficientInventory,
                "Insufficient available stock. Quantity more than available",
                400
            );
        }
        
        ReservedQuantity += quantity;
        AvailableQuantity -= quantity;
    }
}