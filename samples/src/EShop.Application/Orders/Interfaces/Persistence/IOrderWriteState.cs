using DevSource.Stack.Core;

namespace EShop.Application.Orders.Interfaces.Persistence;

public interface IOrderWriteState : IState
{
    IOrderWriteRepository Order { get; }
}