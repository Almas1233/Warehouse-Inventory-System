using FluentValidation;
using WarehouseInventorySystem.Application.Handlers.Common.Interfaces;
using WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Products;
using WarehouseInventorySystem.Products.Models;

namespace WarehouseInventorySystem.Application.Handlers.Features.Products.CreateProduct;

public class CreateProductRequestHandler: 
    IRequestHandler<CreateProductRequest,CreateProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<CreateProductRequest> _validator;

    public CreateProductRequestHandler(IProductRepository productRepository, IValidator<CreateProductRequest> validator)
    {
        _productRepository = productRepository;
        _validator =  validator;
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request)
    {
        await _validator.ValidateAndThrowAsync(request);
        
        var product = new Product(
            request.Name,
            request.Sku,
            request.Length,
            request.Width,
            request.Height
        );
        
        await _productRepository.AddAsync(product);
        
        var result = new CreateProductResponse(product.Id.ToString());

        return result;
    }
}