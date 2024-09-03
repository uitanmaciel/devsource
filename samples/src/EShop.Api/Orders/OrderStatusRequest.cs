namespace EShop.Api.Orders;

public enum OrderStatusRequest
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