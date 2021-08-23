using System.Collections.Generic;
using System.Linq;
using Exchange.Domain.Item.Response;

namespace Exchange.Domain.User.Response
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<ItemInfo> ItemList { get; set; }


        public static UserInfo MapToInfo(Entity.User toMap)
        {
            if (toMap == null)
            {
                return null;
            }
            
            return new UserInfo()
            {
                Id = toMap.Id,
                Name = toMap.Name,
                ItemList = toMap.ItemList != null ? toMap.ItemList.Select(ItemInfo.MapToInfo).ToList() : null
            };
        }
    }
}