using System.Collections.Generic;
using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces.Queries;

namespace Exchange.Domain.ServiceInterfaces
{
    public interface IItemReadService
    {
        ItemInfo GetItem(int itemId);
        PagedList<ItemInfo> FindItems(FindItemsWithPagingQuery query);
    }
}