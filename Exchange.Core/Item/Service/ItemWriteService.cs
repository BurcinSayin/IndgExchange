using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Response;
using Exchange.Domain.Item.Service;
using Exchange.Domain.Item.Strategy;
using Exchange.Domain.Model;
using Exchange.Services.ConcreteStrategy;

namespace Exchange.Services
{
    public class ItemWriteService:IItemWriteService
    {
        private IItemRepository _itemRepository;
        private IExchangeUserRepository _userRepository;

        private ICreateItemStrategy createStrategy;
        private IUpdateItemStrategy updateStratgy;
        private IDeleteItemStrategy deleteStrategy;

        public ItemWriteService(IItemRepository itemRepository, IExchangeUserRepository userRepository)
        {
            _itemRepository = itemRepository;
            _userRepository = userRepository;
            createStrategy = new CreateItemWithTransaction();
            updateStratgy = new UpdateItemWithTransaction();
            deleteStrategy = new DeleteItemSimple();
        }

        public ItemInfo CreateItem(CreateItemCommand createCommand)
        {
            return createStrategy.Create(_itemRepository,_userRepository, createCommand).ToItemInfo();
        }

        public ItemInfo UpdateItem(UpdateItemCommand command)
        {
            return updateStratgy.Update(_itemRepository,_userRepository, command).ToItemInfo();
        }

        public void DeleteItem(DeleteItemCommand command)
        {
            deleteStrategy.Delete(_itemRepository, _userRepository, command);
        }
    }


}