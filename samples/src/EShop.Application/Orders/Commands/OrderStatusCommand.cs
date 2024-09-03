namespace EShop.Application.Orders.Commands;

public enum OrderStatusCommand
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