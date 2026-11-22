using WarehouseInventorySystem.Contracts.Enums;
using WarehouseInventorySystem.Domain.Common.Base;
using WarehouseInventorySystem.Products.Exception;

namespace WarehouseInventorySystem.Products.Models;

public class Product : BaseDomainModel
{

    public string Name { get; init; }
    public string Sku { get; init; }
    public int Length { get; init; }
    public int Width { get; init; }
    public int Height { get; init; }

    public Product(
        string name,
        string sku,
        int length,
        int width,
        int height
    )
    {

        Name = name;
        Sku = sku;
        Length = length;
        Width = width;
        Height = height;
    }

    public void EnsureProductSize(
        int length,
        int width,
        int height
    )
    {
        if (length < 0 || width < 0 || height < 0)
        {
            throw new DomainProductsValidationException(
                "Size should be greater than 0.", 
                ResponseCode.ProductSizeBelowZero,
                "Invalid validation. Size is below zero.",
                400
            );
        }
    }

}