using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Core.Item.Strategy
{
    class CreateItemWithTransaction:ICreateItemStrategy
    {
        public Domain.Item.Entity.Item Create(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,
            CreateItemCommand command)
        {
            var transaction = itemRepository.BeginTransaction();

            Domain.ExchangeUser.Entity.ExchangeUser itemOwner = null;
            if (command.OwnerId.HasValue)
            {
                itemOwner = exchangeUserRepository.FindById(command.OwnerId.Value, transaction);
            }

            Domain.Item.Entity.Item toCreate = new Domain.Item.Entity.Item()
            {
                Holder = itemOwner,
                ItemName = command.ItemName
            };

            var retVal = itemRepository.Add(toCreate);

            transaction.Commit();

            return retVal;
        }
    }
}
