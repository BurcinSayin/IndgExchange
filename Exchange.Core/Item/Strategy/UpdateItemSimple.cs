using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Core.Item.Strategy
{
    public class UpdateItemSimple:IUpdateItemStrategy
    {
        public Domain.Item.Entity.Item Update(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository, UpdateItemCommand command)
        {
            var targetItem = itemRepository.Get(command.ItemId);

            if (command.HolderId.HasValue)
            {
                targetItem.Holder = exchangeUserRepository.Get(command.HolderId.Value);
            }

            targetItem.ItemName = command.ItemName;

            return itemRepository.Update(targetItem);
        }
    }
}