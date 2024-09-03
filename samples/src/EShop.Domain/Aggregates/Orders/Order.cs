using EShop.Domain.Aggregates.Orders.Enums;
using EShop.Domain.Aggregates.Orders.ValueObjects;

namespace EShop.Domain.Aggregates.Orders;

public sealed class Order : AggregateRoot<Guid>
{
    public Guid CustomerId { get; private set; }
    public OrderStatus Status { get; private set; } =  OrderStatus.None;
    public IList<OrderItem> OrderItems { get; private set; } = [];
    public decimal Total { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public DateTime CanceledOn { get; private set; }
    
    public Order(Guid id) : base(id) { }

    public Order(Guid id, Guid customerId, OrderStatus status, IList<OrderItem> orderItems)
    {
        Id = id;
        CustomerId = customerId;
        Status = status;
        OrderItems = orderItems;
    }
    
    public Order() { }
    
    public void AddItem(OrderItem item)
    {
        OrderItems.Add(item);
        CalculateTotal();
    }
    
    public void RemoveItem(OrderItem item)
    {
        OrderItems.Remove(item);
        CalculateTotal();
    }

    public Task<Order> CreateOrder(Order order,CancellationToken cancellationToken)
    {
        ValidateFields();
        
        if(HasNotifications)
            return Task.FromResult(order);
        
        Id = Guid.NewGuid();
        Status = OrderStatus.Created;
        CreatedOn = DateTime.UtcNow;
        
        return Task.FromResult(order);
    }
    
    public Task<Order> CancelOrder(Order order,CancellationToken cancellationToken)
    {
        if (Status == OrderStatus.Canceled)
        {
            AddNotification(nameof(Status), "Order already canceled");
            return Task.FromResult(order);
        }
        
        Status = OrderStatus.Canceled;
        CanceledOn = DateTime.UtcNow;
        
        return Task.FromResult(order);
    }
    
    private void CalculateTotal()
        => Total = OrderItems.Sum(x => x.Total);
    
    private void ValidateFields()
    {
        AddNotifications(new ValidationRules<Order>()
            .IsGuidNotEmpty("Customer", CustomerId)
            .IsGreaterThan(nameof(OrderItems), OrderItems.Count, 0)
        );
        
        if(OrderItems.Any(x => x.HasNotifications))
            AddNotifications(OrderItems.SelectMany(x => x.Notifications));
    }
}