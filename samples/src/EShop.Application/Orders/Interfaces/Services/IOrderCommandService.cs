using EShop.Application.Orders.Commands.Cancel;
using EShop.Application.Orders.Commands.Create;

namespace EShop.Application.Orders.Interfaces.Services;

public interface IOrderCommandService
{
    Task<bool> CreateOrderAsync(OrderCreateCommand order, CancellationToken cancellationToken);
    Task<bool> CancelOrderAsync(OrderCancelCommand order, CancellationToken cancellationToken);
}