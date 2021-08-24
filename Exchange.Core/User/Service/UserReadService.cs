using System;
using System.Linq;
using Exchange.Core.Shared;
using Exchange.Core.User.Validator;
using Exchange.Domain.Common.Response;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Query;
using Exchange.Domain.User.Response;
using Exchange.Domain.User.Service;
using FluentValidation;

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
            GetUserQueryValidator validator = new GetUserQueryValidator();
            validator.ValidateAndThrow(query);
            
            return _userRepository.Get(query.UserId).ToUserInfo();
        }

        public PagedList<UserInfo> GetUsers(GetUsersWithPagingQuery query)
        {
            GetUsersWithPagingQueryValidator validator = new GetUsersWithPagingQueryValidator();
            validator.ValidateAndThrow(query);
            
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