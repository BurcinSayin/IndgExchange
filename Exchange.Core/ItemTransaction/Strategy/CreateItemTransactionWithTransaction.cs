using System;
using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ItemTransaction.Command;
using Exchange.Domain.ItemTransaction.Strategy;

namespace Exchange.Core.ItemTransaction.Strategy
{
    public class CreateItemTransactionWithTransaction:ICreateItemTransactionStrategy
    {
        public Domain.ItemTransaction.Entity.ItemTransaction Create(IItemRepository itemRepository, IUserRepository userRepository,
            IItemTransactionRepository transactionRepository, CreateItemTransactionCommand command)
        {
            var dbTransaction = transactionRepository.BeginTransaction();

            Domain.Item.Entity.Item fromItem = null;

            fromItem = itemRepository.FindById(command.TakenItemId, dbTransaction);
            if (fromItem == null)
            {
                dbTransaction.Rollback();
                throw new NotFoundException("Given Item Not Found.");
            }
            Domain.User.Entity.User fromUser = null;
            if (command.GivingUserId.HasValue)
            {
                fromUser = userRepository.FindById(command.GivingUserId.Value, dbTransaction);
                if (fromUser == null)
                {
                    dbTransaction.Rollback();
                    throw new NotFoundException("Giving User Not Found.");
                }
            }

            Domain.Item.Entity.Item toItem = null;
            if (command.ExchangedItemId.HasValue)
            {
                toItem = itemRepository.FindById(command.ExchangedItemId.Value, dbTransaction);
                if (toItem == null)
                {
                    dbTransaction.Rollback();
                    throw new NotFoundException("Exchanged Item Not Found.");
                }            
            }
            Domain.User.Entity.User toUser = null;

            toUser = userRepository.FindById(command.TakingUserId, dbTransaction);
            if (toUser == null)
            {
                dbTransaction.Rollback();
                throw new NotFoundException("Taking User Not Found.");
            }            



            if (fromUser != null && toItem == null)
            {
                dbTransaction.Rollback();
                throw new NotFoundException("Exchanged Item Not Found.");
            }
            if (fromUser == null && toItem != null)
            {
                dbTransaction.Rollback();
                throw new NotFoundException("Exchanged User Not Found.");
            }

            Domain.ItemTransaction.Entity.ItemTransaction toCreate = new Domain.ItemTransaction.Entity.ItemTransaction()
            {
                CreatedAt = DateTime.Now,
                TakenItemId = fromItem.Id,
                TakingUserId = toUser.Id
            };

            if (fromUser != null)
            {
                toCreate.GivingUserId = fromUser.Id;
            }

            if (toItem != null)
            {
                toCreate.ExchangedItemId = toItem.Id;
            }

            var retVal = transactionRepository.Add(toCreate);

            fromItem.User = toUser;
            itemRepository.Update(fromItem);
            if (toItem != null)
            {
                toItem.User = fromUser;
                itemRepository.Update(toItem);
            }
            
            dbTransaction.Commit();

            return retVal;
        }

    }
}