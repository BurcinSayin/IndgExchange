using Exchange.Domain.Common.Response;
using Exchange.Domain.ExchangeUser.Query;
using Exchange.Domain.ExchangeUser.Response;

namespace Exchange.Domain.ExchangeUser.Service
{
    public interface IExchangeUserReadService
    {
        ExchangeUserInfo GetExchangeUser(GetUserQuery query);
        PagedList<ExchangeUserInfo> GetExchangeUsers(GetUsersWithPagingQuery query);
    }
}