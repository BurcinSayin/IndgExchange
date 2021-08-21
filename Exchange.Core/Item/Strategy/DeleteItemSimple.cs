using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Core.Item.Strategy
{
    public class DeleteItemSimple:IDeleteItemStrategy
    {
        public bool Delete(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository, DeleteItemCommand command)
        {
            return itemRepository.Delete(command.ItemId);
        }
    }
}