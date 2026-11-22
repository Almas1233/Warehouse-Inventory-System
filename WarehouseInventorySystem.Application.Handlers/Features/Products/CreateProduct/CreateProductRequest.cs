namespace WarehouseInventorySystem.Application.Handlers.Features.Products.CreateProduct;

public record CreateProductRequest(
    string Name, 
    string Sku, 
    int Length, 
    int Width, 
    int Height
);