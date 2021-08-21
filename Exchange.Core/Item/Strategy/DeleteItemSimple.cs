using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Services.ConcreteStrategy
{
    public class DeleteItemSimple:IDeleteItemStrategy
    {
        public bool Delete(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository, DeleteItemCommand command)
        {
            return itemRepository.Delete(command.ItemId);
        }
    }
}