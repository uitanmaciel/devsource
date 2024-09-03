using DevSource.Stack.Core.State;

namespace EShop.Application.Orders.Interfaces.Persistence;

public interface IOrderReadRepository : IReadRepositoryAsync<Order>
{
    Task<IQueryable<Order>> GetOrdersByCreatedOnAsync(DateTime createdOn, CancellationToken cancellationToken);
    Task<IQueryable<Order>> GetOrdersByCanceledOnAsync(DateTime canceledOn, CancellationToken cancellationToken);
    Task<IQueryable<Order>> GetOrderByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken);
}