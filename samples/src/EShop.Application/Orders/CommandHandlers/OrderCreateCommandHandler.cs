using DevSource.Stack.Core;
using DevSource.Stack.Core.Application.Handlers.CommandHandlers;
using DevSource.Stack.Core.Internal;
using EShop.Application.Orders.Commands.Create;
using EShop.Application.Orders.Interfaces.Persistence;
using EShop.Domain.Aggregates.Orders.Events;

namespace EShop.Application.Orders.CommandHandlers;

public class OrderCreateCommandHandler(IOrderWriteState writeState, ITransactionFactory transaction) : 
    CommandHandlerAsync<OrderCreateCommand, dynamic, IOrderWriteState>(writeState)
{
    public override async Task<dynamic> HandleAsync(OrderCreateCommand command, CancellationToken cancellationToken)
    {
        var objectDomain = command.ToDomain(command);
        var domain = new Order();
        var order = await domain.CreateOrder(objectDomain, cancellationToken);
        
        await ExecuteTransaction(async () =>
        {
            if (order.HasNotifications)
                return order.HasNotifications;

            var result = await WriteState.Order.InsertAsync(order, cancellationToken);

            if (result < 1)
            {
                AddNotification("Order", "Order not created");
                return order.HasNotifications;
            }

            var @event = new OrderCreated(order);
            var publish = await ProcessEventAsync<bool>(@event, cancellationToken);

            if (!publish)
                AddNotification("Order", "Order not published");

            return true;
        });
        
        return order;
    }
}