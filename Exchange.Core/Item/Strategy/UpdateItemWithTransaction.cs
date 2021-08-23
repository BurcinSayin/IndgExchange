using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Core.Item.Strategy
{
    public class UpdateItemWithTransaction:IUpdateItemStrategy
    {
        public Domain.Item.Entity.Item Update(IItemRepository itemRepository, IUserRepository userRepository, UpdateItemCommand command)
        {
            var transaction = itemRepository.BeginTransaction();

            var targetItem = itemRepository.FindById(command.ItemId, transaction);

            if (targetItem == null)
            {
                transaction.Rollback();
                throw new NotFoundException("Item Not Found.");
            }

            if (command.HolderId.HasValue)
            {
                targetItem.User = userRepository.FindById(command.HolderId.Value, transaction);
            }

            targetItem.ItemName = command.ItemName;

            var retVal =itemRepository.Update(targetItem);
            
            transaction.Commit();

            return retVal;
        }
    }
}