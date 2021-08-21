using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;
using Exchange.Domain.Strategy;
using Exchange.Services.ConcreteStrategy;

namespace Exchange.Services
{
    public class ItemWriteService:IItemWriteService
    {
        private IItemRepository _itemRepository;
        private IExchangeUserRepository _userRepository;

        private ICreateItemStrategy itemCreator;

        public ItemWriteService(IItemRepository itemRepository, IExchangeUserRepository userRepository)
        {
            _itemRepository = itemRepository;
            _userRepository = userRepository;
            itemCreator = new CreateItemWithTransaction();
        }

        public ItemInfo CreateItem(CreateItemCommand createCommand)
        {
            return itemCreator.Create(_itemRepository,_userRepository, createCommand).ToItemInfo();
        }
    }


}