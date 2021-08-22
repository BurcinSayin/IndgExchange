using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Core.Item.Strategy
{
    public class DeleteItemSimple:IDeleteItemStrategy
    {
        public bool Delete(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository, DeleteItemCommand command)
        {
            bool retVal = itemRepository.Delete(command.ItemId);
            
            if (!retVal)
            {
                throw new NotFoundException("Item Not Found.");
            }

            return true;
        }
    }
}