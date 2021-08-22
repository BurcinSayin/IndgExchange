using System;
using System.Linq;
using Exchange.Core.Shared;
using Exchange.Domain.Common.Response;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Query;
using Exchange.Domain.Item.Response;
using Exchange.Domain.Item.Service;

namespace Exchange.Core.Item.Service
{
    public class ItemReadService:IItemReadService
    {
        private readonly IItemRepository _itemRepository;

        public ItemReadService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public ItemInfo GetItem(GetItemQuery query)
        {
            var item = _itemRepository.Get(query.ItemId);

            return item.ToItemInfo();
        }

        public PagedList<ItemInfo> GetItems(GetItemsWithPagingQuery query)
        {
            var fullData = _itemRepository.GetAll();

            
            if (query.OwnerId.HasValue)
            {
                fullData = fullData.Where(it => it.Holder != null && it.Holder.Id == query.OwnerId.Value);
            }

            if (!string.IsNullOrWhiteSpace(query.ItemName))
            {
                fullData = fullData.Where(it =>
                    it.ItemName.Equals(query.ItemName, StringComparison.InvariantCultureIgnoreCase));
            }



            var count = fullData.Count();
            var result = fullData.OrderBy(it=>it.Id).Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize)
                .Select(it =>ItemInfo.MapToInfo(it))
                .ToList();

            return new PagedList<ItemInfo>(result, query.PageNumber, query.PageSize, count);
        }
    }
}