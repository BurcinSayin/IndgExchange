using Exchange.Domain.Common.Response;
using Exchange.Domain.Item.Query;
using Exchange.Domain.Item.Response;

namespace Exchange.Domain.Item.Service
{
    public interface IItemReadService
    {
        ItemInfo GetItem(int itemId);
        PagedList<ItemInfo> FindItems(FindItemsWithPagingQuery query);
    }
}