namespace EShop.Domain.Aggregates.Orders.Enums;

public enum OrderStatus
{
    Created,
    InProcess,
    Paid,
    Shipped,
    Delivered,
    Canceled,
    Refunded,
    Returned,
    Disputed,
    Lost,
    None
}