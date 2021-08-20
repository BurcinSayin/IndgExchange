using System.Collections.Generic;
using Exchange.Domain.Model;

namespace Exchange.Domain.ServiceInterfaces
{
    public interface IItemReadService
    {
        IEnumerable<ItemInfo> GetAllItems();
    }
}