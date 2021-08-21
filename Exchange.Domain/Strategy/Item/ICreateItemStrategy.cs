using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Domain.Strategy.Item
{
    public interface ICreateItemStrategy
    {
        DataInterfaces.Item Create(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,CreateItemCommand command);
    }
}
