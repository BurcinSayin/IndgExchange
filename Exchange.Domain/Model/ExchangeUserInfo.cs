using System.Collections.Generic;
using System.Linq;
using Exchange.Domain.DataInterfaces;

namespace Exchange.Domain.Model
{
    public class ExchangeUserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<ItemInfo> ItemList { get; set; }


        public static ExchangeUserInfo MapToInfo(ExchangeUser toMap)
        {
            return new ExchangeUserInfo()
            {
                Id = toMap.Id,
                Name = toMap.Name,
                ItemList = toMap.ItemList.Select(ItemInfo.MapToInfo).ToList()
            };
        }
    }
}