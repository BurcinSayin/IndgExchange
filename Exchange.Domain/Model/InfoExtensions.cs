using Exchange.Domain.DataInterfaces;

namespace Exchange.Domain.Model
{
    public static class InfoExtensions
    {
        public static ItemInfo ToItemInfo(this Item source)
        {
            return ItemInfo.MapToInfo(source);
        }
        
        public static ExchangeUserInfo ToExchangeUserInfo(this ExchangeUser source)
        {
            return ExchangeUserInfo.MapToInfo(source);
        }
    }
}