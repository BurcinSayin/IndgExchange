using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Core.Item.Strategy
{
    public class CreateItemWithTransaction:ICreateItemStrategy
    {
        public Domain.Item.Entity.Item Create(IItemRepository itemRepository, IUserRepository userRepository,
            CreateItemCommand command)
        {
            var transaction = itemRepository.BeginTransaction();

            Domain.User.Entity.User itemOwner = null;
            if (command.OwnerId.HasValue)
            {
                itemOwner = userRepository.FindById(command.OwnerId.Value, transaction);
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
