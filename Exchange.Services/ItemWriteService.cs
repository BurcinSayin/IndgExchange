using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;
using Exchange.Domain.Strategy;

namespace Exchange.Services
{
    public class ItemWriteService:IItemWriteService
    {
        private IItemRepository _itemRepository;
        private IExchangeUserRepository _userRepository;

        public ItemWriteService(IItemRepository itemRepository, IExchangeUserRepository userRepository)
        {
            _itemRepository = itemRepository;
            _userRepository = userRepository;
        }

        public ItemInfo CreateItem(CreateItemCommand createCommand)
        {
            ExchangeUser itemOwner = null;
            if (createCommand.OwnerId.HasValue)
            {
                itemOwner = _userRepository.Get(createCommand.OwnerId.Value);
            }

            Item toCreate = new Item()
            {
                Holder = itemOwner,
                ItemName = createCommand.ItemName
            };

            var retVal = _itemRepository.Add(toCreate);

            return new ItemInfo()
            {
                Id = retVal.Id,
                ItemName = retVal.ItemName,
                Owner = retVal.Holder?.Name
            };
        }
    }


}