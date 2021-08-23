using Exchange.Domain.Common.Response;
using Exchange.Domain.User.Query;
using Exchange.Domain.User.Response;

namespace Exchange.Domain.User.Service
{
    public interface IUserReadService
    {
        UserInfo GetUser(GetUserQuery query);
        PagedList<UserInfo> GetUsers(GetUsersWithPagingQuery query);
    }
}