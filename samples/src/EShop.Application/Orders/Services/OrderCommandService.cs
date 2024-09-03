using DevSource.Stack.Core.Application;
using EShop.Application.Orders.Commands.Cancel;
using EShop.Application.Orders.Commands.Create;
using EShop.Application.Orders.Interfaces.Services;

namespace EShop.Application.Orders.Services;

public class OrderCommandService : ApplicationServices, IOrderCommandService
{
    public async Task<bool> CreateOrderAsync(OrderCreateCommand order, CancellationToken cancellationToken)
    {
        var result = await ProcessCommandAsync<object?>(order, cancellationToken);
        return result is not null;
    }

    public async Task<bool> CancelOrderAsync(OrderCancelCommand order, CancellationToken cancellationToken)
    {
        var result = await ProcessCommandAsync<object?>(order, cancellationToken);
        return result is not null;
    }
}