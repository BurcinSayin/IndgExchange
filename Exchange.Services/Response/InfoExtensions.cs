using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Response;
using Exchange.Domain.Item.Response;

namespace Exchange.Domain.Model
{
    public static class InfoExtensions
    {
        public static ItemInfo ToItemInfo(this Item.Entity.Item source)
        {
            return ItemInfo.MapToInfo(source);
        }
        
        public static ExchangeUserInfo ToExchangeUserInfo(this ExchangeUser.Entity.ExchangeUser source)
        {
            return ExchangeUserInfo.MapToInfo(source);
        }
    }
}