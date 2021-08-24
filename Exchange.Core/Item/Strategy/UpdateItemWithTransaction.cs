using System;
using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Core.Item.Strategy
{
    public class UpdateItemWithTransaction:IUpdateItemStrategy
    {
        public Domain.Item.Entity.Item Update(IItemRepository itemRepository, IUserRepository userRepository,IItemTransactionRepository transactionRepository, UpdateItemCommand command)
        {
            var dbTransaction = itemRepository.BeginTransaction();

            var targetItem = itemRepository.FindById(command.ItemId, dbTransaction);

            if (targetItem == null)
            {
                dbTransaction.Rollback();
                throw new NotFoundException("Item Not Found.");
            }

            if (targetItem.User != null)
            {
                dbTransaction.Rollback();
                throw new NotFoundException("Item Already Owned.");
            }

            if (command.HolderId.HasValue)
            {
                targetItem.User = userRepository.FindById(command.HolderId.Value, dbTransaction);
            }

            if (targetItem.User != null)
            {
                var itemTran = new Domain.ItemTransaction.Entity.ItemTransaction()
                {
                    CreatedAt = DateTime.Now,
                    ExchangedItemId = null,
                    GivingUserId = null,
                    TakenItemId = targetItem.Id,
                    TakingUserId = targetItem.User.Id
                };
                transactionRepository.Add(itemTran);
            }

            targetItem.ItemName = command.ItemName;

            var retVal =itemRepository.Update(targetItem);
            

            
            dbTransaction.Commit();

            return retVal;
        }
    }
}