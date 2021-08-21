using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Domain.Strategy.Item
{
    public interface IUpdateItemStrategy
    {
        DataInterfaces.Item Update(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,UpdateItemCommand command);
    }
}