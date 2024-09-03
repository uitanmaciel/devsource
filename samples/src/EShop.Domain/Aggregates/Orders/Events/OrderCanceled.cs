namespace EShop.Domain.Aggregates.Orders.Events;

public record OrderCanceled(Order Order) : DomainEvent;