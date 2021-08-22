using Exchange.Domain.Common.Response;
using Exchange.Domain.Item.Query;
using Exchange.Domain.Item.Response;

namespace Exchange.Domain.Item.Service
{
    public interface IItemReadService
    {
        ItemInfo GetItem(GetItemQuery query);
        PagedList<ItemInfo> GetItems(GetItemsWithPagingQuery query);
    }
}