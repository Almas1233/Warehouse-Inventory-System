using System.Text.RegularExpressions;
using WarehouseInventorySystem.Application.Handlers.Common.Interfaces;
using WarehouseInventorySystem.Application.Handlers.Enums;
using WarehouseInventorySystem.Application.Handlers.Exceptions;

namespace WarehouseInventorySystem.Application.Handlers.Features.Inventories.ShippingStock.ReserveStock.ConfirmReserving;

public class ConfirmReservingHandler :
    IRequestHandler<ConfirmReservingRequest, ConfirmReservingResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IStorageCellRepository _storageCellRepository;

    public ConfirmReceivingHandler(
        IProductRepository productRepository,
        IInventoryRepository inventoryRepository,
        IStorageCellRepository storageCellRepository
    )
    {
        _productRepository = productRepository;
        _inventoryRepository = inventoryRepository;
        _storageCellRepository = storageCellRepository;
    }

    public async Task<ConfirmReservingResponse> Handle(ConfirmReservingRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.StorageCellId)
            || string.IsNullOrWhiteSpace(request.Sku) // Separate checks
           )
        {
            throw new InvalidValidation(
                "Storage cell or Sku are empty.",
                ErrorCodes.InvalidInput
            );
        }

        if (!Regex.IsMatch(request.Sku, @"^[a-zA-Z0-9]{8}$") // Separate checks
            || request.Quantity <= 0
           )
        {
            throw new InvalidValidation(
                "Sku should have 8 signs and be more than 0.",
                ErrorCodes.InvalidInput
            );
        }

        var product = await _productRepository.GetBySkuAsync(request.Sku); //Replace with Id

        if (product == null) //Can I remove it?
        {
            throw new NotFoundException(
                "Product not found.",
                ErrorCodes.ProductNotFound
            );
        }

        var cell = await _storageCellRepository.GetByIdAsync(request.StorageCellId); //Can I remove it?

        if (cell == null)
        {
            throw new NotFoundException(
                "Storage cell not found.",
                ErrorCodes.StorageCellNotFound
            );
        }

        var balance = await _inventoryRepository.GetByStorageCellIdAsync(request.StorageCellId);

        if (balance == null)
        {
            throw new NotFoundException(
                "Inventory balance not found.", 
                ErrorCodes.InventoryBalanceNotFound
            );
        }
        
        balance.Reserve(request.Quantity);

        await _inventoryRepository.SaveChangesAsync();
        
        var result = new ConfirmReservingResponse(
            product.Id.ToString(), 
            cell.Id.ToString(), 
            request.Quantity
        );

        return result;
    }
}