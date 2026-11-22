using Microsoft.AspNetCore.Mvc;
using WarehouseInventorySystem.Application.Handlers.Common.Interfaces;
using WarehouseInventorySystem.Application.Handlers.Features.Products.CreateProduct;

namespace WarehouseInventorySystem.WebApi.Controller;

[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    [HttpPost]
    [Route("add_new_product")]
    public async Task<CreateProductResponse> AddNewProduct(
        CreateProductRequest request,
        [FromServices] IRequestHandler<CreateProductRequest, CreateProductResponse> handler
    )
    {
        var result = await handler.Handle(request);
        
        return result;
    }
    
    [HttpGet("test-unh-error")]
    public IActionResult TestUnh()
    {
        throw new Exception("Something went wrong");
    }
    
    [HttpGet("test-arg-error")]
    public IActionResult TestArg()
    {
        throw new ArgumentException("Test");
    }
    
    [HttpGet("test-inv-error")]
    public IActionResult TestInv()
    {
        throw new InvalidOperationException("Test");
    }
    
    
    
}