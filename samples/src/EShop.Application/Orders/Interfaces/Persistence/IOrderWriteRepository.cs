using DevSource.Stack.Core.State;

namespace EShop.Application.Orders.Interfaces.Persistence;

public interface IOrderWriteRepository : IWriteRepositoryAsync<Order>
{
    Task<int> CancelOrderAsync(Order order, CancellationToken cancellationToken);
}
