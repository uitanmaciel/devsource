namespace EShop.Domain.Aggregates.Orders.Events;

public record OrderCreated(Order Order) : DomainEvent;