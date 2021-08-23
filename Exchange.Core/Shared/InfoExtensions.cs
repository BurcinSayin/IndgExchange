using Exchange.Domain.Item.Response;
using Exchange.Domain.User.Response;

namespace Exchange.Core.Shared
{
    public static class InfoExtensions
    {
        public static ItemInfo ToItemInfo(this Domain.Item.Entity.Item source)
        {
            return ItemInfo.MapToInfo(source);
        }
        
        public static UserInfo ToUserInfo(this Domain.User.Entity.User source)
        {
            return UserInfo.MapToInfo(source);
        }
    }
}