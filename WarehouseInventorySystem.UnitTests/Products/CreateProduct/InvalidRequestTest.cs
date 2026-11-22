using FluentValidation;
using Moq;
using WarehouseInventorySystem.Application.Handlers.Features.Products.CreateProduct;
using WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Products;


namespace UnitTests.Products.CreateProduct;

public class InvalidRequestTest
{
    private readonly Mock<IProductRepository> _repositoryMock = new();
    private readonly Mock<IValidator<CreateProductRequest>> _validatorMock = new();

    private CreateProductRequestHandler CreateHandler()
    {
        return new CreateProductRequestHandler(
            _repositoryMock.Object,
            _validatorMock.Object);
    }
    
}