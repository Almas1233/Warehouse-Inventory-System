namespace WarehouseInventorySystem.Application.Handlers.Common.Interfaces;

public interface IRequestHandler<in TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request);
}