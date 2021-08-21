using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;
using Exchange.Domain.Strategy.Item;

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