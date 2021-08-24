using System;
using System.Linq;
using Exchange.Core.Shared;
using Exchange.Domain.Common.Response;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Query;
using Exchange.Domain.User.Response;
using Exchange.Domain.User.Service;

namespace Exchange.Core.User.Service
{
    public class UserReadService:IUserReadService
    {
        private readonly IUserRepository _userRepository;

        public UserReadService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public UserInfo GetUser(GetUserQuery query)
        {
            return _userRepository.Get(query.UserId).ToUserInfo();
        }

        public PagedList<UserInfo> GetUsers(GetUsersWithPagingQuery query)
        {
            var resultList = _userRepository.GetAll();

            if (!string.IsNullOrEmpty(query.UserName))
            {
                resultList = resultList.Where(usr =>
                    query.UserName.Equals(usr.Name));
            }
            
            var count = resultList.Count();
            var result = resultList.OrderBy(it=>it.Id).Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(usr => UserInfo.MapToInfo(usr))
                .ToList();

            return new PagedList<UserInfo>(result, query.PageNumber, query.PageSize, count);
        }
    }
}