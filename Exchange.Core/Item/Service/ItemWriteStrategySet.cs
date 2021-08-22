using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Response;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Core.Item.Service
{
    public class ItemWriteStrategySet
    {
        private ICreateItemStrategy createStrategy;
        private IUpdateItemStrategy updateStratgy;
        private IDeleteItemStrategy deleteStrategy;

        public ItemWriteStrategySet( ICreateItemStrategy createStrategy, IUpdateItemStrategy updateStratgy,IDeleteItemStrategy deleteStrategy)
        {
            this.deleteStrategy = deleteStrategy;
            this.updateStratgy = updateStratgy;
            this.createStrategy = createStrategy;
        }

        public Domain.Item.Entity.Item Create(IItemRepository itemRepository, IExchangeUserRepository userRepository, CreateItemCommand createCommand)
        {
            return createStrategy.Create(itemRepository, userRepository, createCommand);
        }

        public Domain.Item.Entity.Item Update(IItemRepository itemRepository, IExchangeUserRepository userRepository, UpdateItemCommand command)
        {
            return updateStratgy.Update(itemRepository, userRepository, command);
        }

        public bool Delete(IItemRepository itemRepository, IExchangeUserRepository userRepository, DeleteItemCommand command)
        {
            return deleteStrategy.Delete(itemRepository, userRepository, command);
        }
    }
}