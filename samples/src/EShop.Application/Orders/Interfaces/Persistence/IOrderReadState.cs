using DevSource.Stack.Core;

namespace EShop.Application.Orders.Interfaces.Persistence;

public interface IOrderReadState : IState
{
    IOrderReadRepository Order { get; }
}