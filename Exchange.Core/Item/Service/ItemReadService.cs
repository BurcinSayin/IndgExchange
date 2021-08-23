using System;
using System.Linq;
using Exchange.Core.Item.Validator;
using Exchange.Core.Shared;
using Exchange.Domain.Common.Response;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Query;
using Exchange.Domain.Item.Response;
using Exchange.Domain.Item.Service;
using FluentValidation;

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
            GetItemQueryValidator validator = new GetItemQueryValidator();
            
            validator.ValidateAndThrow(query);
            
            var item = _itemRepository.Get(query.ItemId);

            return item.ToItemInfo();
        }

        public PagedList<ItemInfo> GetItems(GetItemsWithPagingQuery query)
        {

            GetItemsWithPagingQueryValidator validator = new GetItemsWithPagingQueryValidator();
            validator.ValidateAndThrow(query);
            
            var fullData = _itemRepository.GetAll();
            
            if (query.OwnerId.HasValue)
            {
                fullData = fullData.Where(it => it.User != null && it.User.Id == query.OwnerId.Value);
            }

            if (!string.IsNullOrWhiteSpace(query.ItemName))
            {
                fullData = fullData.Where(it =>
                    it.ItemName.Equals(query.ItemName, StringComparison.InvariantCultureIgnoreCase));
            }



            var count = fullData.Count();
            var result = fullData.OrderBy(it=>it.Id).Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(it => new {it,it.User})
                .Select(arg => ItemInfo.MapToInfo(arg.it))
                .ToList();


            
            return new PagedList<ItemInfo>(result.ToList(), query.PageNumber, query.PageSize, count);
        }
    }
}