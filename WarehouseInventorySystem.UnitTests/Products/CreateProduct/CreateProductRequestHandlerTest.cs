using FluentValidation;
using FluentValidation.Results;
using Moq;
using WarehouseInventorySystem.Application.Handlers.Features.Products.CreateProduct;
using WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Products;
using WarehouseInventorySystem.Products.Models;
using Xunit;

namespace UnitTests.Products.CreateProduct;

public class CreateProductRequestHandlerTest
{
    private readonly Mock<IProductRepository> _repositoryMock = new();
    private readonly Mock<IValidator<CreateProductRequest>> _validatorMock = new();

    private CreateProductRequestHandler CreateHandler()
    {
        return new CreateProductRequestHandler(
            _repositoryMock.Object,
            _validatorMock.Object);
    }

    [Fact]
    public async Task CreatesProductRequestHandlerValidation()
    {
        var request = new CreateProductRequest
        (
            "Laptop",
            "ADC24QTR",
            20,
            10,
            4
        );
        
        _validatorMock  
            .Setup(x => x.ValidateAsync(
                request))
            .ReturnsAsync(new ValidationResult()); 
        
        Product? savedProduct = null;

        _repositoryMock
            .Setup(x => x.AddAsync(It.IsAny<Product>()))
            .Callback<Product>(product => savedProduct = product)
            .ReturnsAsync(1);

        var handler = CreateHandler();
        
        var response = await handler.Handle(request);
        
        var product = Assert.IsType<Product>(savedProduct);

        Assert.Equal(request.Name, product.Name);
        Assert.Equal(request.Sku, product.Sku);
        Assert.Equal(request.Length, product.Length);
        Assert.Equal(request.Width, product.Width);
        Assert.Equal(request.Height, product.Height);

        Assert.Equal(product.Id.ToString(), response.Id);

        _repositoryMock.Verify(
            x => x.AddAsync(It.IsAny<Product>()),
            Times.Once);
    }
}