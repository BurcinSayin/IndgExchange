using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces.Queries;

namespace Exchange.Domain.ServiceInterfaces
{
    public interface IExchangeUserReadService
    {
        ExchangeUserInfo GetItem(int id);
        PagedList<ExchangeUserInfo> FindItems(FindUsersWithPagingQuery query);
    }
}