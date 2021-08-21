using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Entity;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Services.ConcreteStrategy
{
    public class UpdateItemWithTransaction:IUpdateItemStrategy
    {
        public Item Update(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository, UpdateItemCommand command)
        {
            var transaction = itemRepository.BeginTransaction();

            var targetItem = itemRepository.FindById(command.ItemId, transaction);

            if (command.HolderId.HasValue)
            {
                targetItem.Holder = exchangeUserRepository.FindById(command.HolderId.Value, transaction);
            }

            targetItem.ItemName = command.ItemName;

            var retVal =itemRepository.Update(targetItem);
            
            transaction.Commit();

            return retVal;
        }
    }
}