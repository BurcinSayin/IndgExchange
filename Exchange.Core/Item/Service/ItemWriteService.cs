using Exchange.Core.Item.Strategy;
using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Response;
using Exchange.Domain.Item.Service;
using Exchange.Domain.Item.Strategy;

namespace Exchange.Core.Item.Service
{
    public class ItemWriteService:IItemWriteService
    {
        private IItemRepository _itemRepository;
        private IExchangeUserRepository _userRepository;

        // private ICreateItemStrategy createStrategy;
        // private IUpdateItemStrategy updateStratgy;
        // private IDeleteItemStrategy deleteStrategy;

        private ItemWriteStrategySet _writeStrategySet;

        public ItemWriteService(ItemWriteStrategySet strategySet,IItemRepository itemRepository, IExchangeUserRepository userRepository)
        {
            _itemRepository = itemRepository;
            _userRepository = userRepository;
            // createStrategy = new CreateItemWithTransaction();
            // updateStratgy = new UpdateItemWithTransaction();
            // deleteStrategy = new DeleteItemSimple();

            _writeStrategySet = strategySet;
        }

        public ItemInfo CreateItem(CreateItemCommand createCommand)
        {
            return _writeStrategySet.Create(_itemRepository,_userRepository, createCommand).ToItemInfo();
        }

        public ItemInfo UpdateItem(UpdateItemCommand command)
        {
            return _writeStrategySet.Update(_itemRepository,_userRepository, command).ToItemInfo();
        }

        public void DeleteItem(DeleteItemCommand command)
        {
            _writeStrategySet.Delete(_itemRepository, _userRepository, command);
        }
    }


}