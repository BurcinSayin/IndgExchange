using System;
using System.Collections.Generic;
using System.Linq;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces;
using Exchange.Domain.ServiceInterfaces.Queries;

namespace Exchange.Services
{
    public class ItemReadService:IItemReadService
    {
        private readonly IItemRepository _itemRepository;

        public ItemReadService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public ItemInfo GetItem(int itemId)
        {
            var item = _itemRepository.Get(itemId);

            return new ItemInfo()
            {
                Id = item.Id,
                ItemName = item.ItemName,
                Owner = item.Holder != null ? item.Holder.Name : null
            };
        }

        public PagedList<ItemInfo> FindItems(FindItemsWithPagingQuery query)
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
            var result = fullData.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize)
                .Select(it =>new ItemInfo()
                {
                    Id = it.Id,
                    ItemName = it.ItemName,
                    Owner = it.Holder != null ? it.Holder.Name : null
                })
                .ToList();

            return new PagedList<ItemInfo>(result, query.PageNumber, query.PageSize, count);
        }
    }
}