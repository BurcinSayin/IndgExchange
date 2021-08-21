using Exchange.Domain.ExchangeUser.Response;
using Exchange.Domain.Item.Response;

namespace Exchange.Core.Shared
{
    public static class InfoExtensions
    {
        public static ItemInfo ToItemInfo(this Domain.Item.Entity.Item source)
        {
            return ItemInfo.MapToInfo(source);
        }
        
        public static ExchangeUserInfo ToExchangeUserInfo(this Domain.ExchangeUser.Entity.ExchangeUser source)
        {
            return ExchangeUserInfo.MapToInfo(source);
        }
    }
}