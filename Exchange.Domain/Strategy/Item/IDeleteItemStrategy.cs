using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Domain.Strategy.Item
{
    public interface IDeleteItemStrategy
    {
        bool Delete(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,DeleteItemCommand command);
    }

}