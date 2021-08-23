using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Core.Item.Strategy
{
    public class UpdateItemSimple:IUpdateItemStrategy
    {
        public Domain.Item.Entity.Item Update(IItemRepository itemRepository, IUserRepository userRepository, UpdateItemCommand command)
        {
            var targetItem = itemRepository.Get(command.ItemId);

            if (targetItem == null)
            {
                throw new NotFoundException("Item Not Found.");
            }

            if (command.HolderId.HasValue)
            {
                targetItem.Holder = userRepository.Get(command.HolderId.Value);
            }

            targetItem.ItemName = command.ItemName;

            return itemRepository.Update(targetItem);
        }
    }
}