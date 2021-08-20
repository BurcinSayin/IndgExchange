using System.Collections.Generic;
using System.Linq;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces;

namespace Exchange.Services
{
    public class ItemReadService:IItemReadService
    {
        private readonly IItemRepository _itemRepository;

        public ItemReadService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<ItemInfo> GetAllItems()
        {
            return _itemRepository.GetAll().Select(item=> new ItemInfo()
            {
                Id = item.Id,
                ItemName = item.ItemName,
                Owner = item.Holder != null ? item.Holder.Name : null
            });
        }
    }
}