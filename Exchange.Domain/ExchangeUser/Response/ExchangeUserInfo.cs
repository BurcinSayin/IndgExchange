using System.Collections.Generic;
using System.Linq;
using Exchange.Domain.Item.Response;

namespace Exchange.Domain.ExchangeUser.Response
{
    public class ExchangeUserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<ItemInfo> ItemList { get; set; }


        public static ExchangeUserInfo MapToInfo(Entity.ExchangeUser toMap)
        {
            return new ExchangeUserInfo()
            {
                Id = toMap.Id,
                Name = toMap.Name,
                ItemList = toMap.ItemList != null ? toMap.ItemList.Select(ItemInfo.MapToInfo).ToList() : null
            };
        }
    }
}