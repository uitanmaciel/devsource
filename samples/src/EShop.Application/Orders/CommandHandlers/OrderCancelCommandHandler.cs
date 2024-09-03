using DevSource.Stack.Core.Application.Handlers.CommandHandlers;
using DevSource.Stack.Core.Internal;
using EShop.Application.Orders.Commands.Cancel;
using EShop.Application.Orders.Interfaces.Persistence;
using EShop.Domain.Aggregates.Orders.Events;

namespace EShop.Application.Orders.CommandHandlers;

public class OrderCancelCommandHandler(IOrderWriteState state, ITransactionFactory transaction) : 
    CommandHandlerAsync<OrderCancelCommand, IOrderWriteState>(state)
{
    public override async Task HandleAsync(OrderCancelCommand command, CancellationToken cancellationToken)
    {
        var objectDomain = command.ToDomain(command);
        var domain = new Order();
        var order = await domain.CancelOrder(objectDomain, cancellationToken);

        await ExecuteTransaction(async () =>
        {
            if(order.HasNotifications)
                return order.HasNotifications;

            var result = await State.Order.CancelOrderAsync(order, cancellationToken);
            
            if(result < 1)
            {
                AddNotification("Order", "Order not canceled");
                return order.HasNotifications;
            }
            
            var @event = new OrderCanceled(order);
            var publish = await ProcessEventAsync<bool>(@event, cancellationToken);
            
            if(!publish)
                AddNotification("Order", "Order not published");
            
            return true;
        });
    }
}