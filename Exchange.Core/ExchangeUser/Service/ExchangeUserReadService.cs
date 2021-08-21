using System;
using System.Linq;
using Exchange.Core.Shared;
using Exchange.Domain.Common.Response;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Query;
using Exchange.Domain.ExchangeUser.Response;
using Exchange.Domain.ExchangeUser.Service;

namespace Exchange.Core.ExchangeUser.Service
{
    public class ExchangeUserReadService:IExchangeUserReadService
    {
        private readonly IExchangeUserRepository _exchangeUserRepository;

        public ExchangeUserReadService(IExchangeUserRepository exchangeUserRepository)
        {
            _exchangeUserRepository = exchangeUserRepository;
        }


        public ExchangeUserInfo GetItem(int id)
        {
            return _exchangeUserRepository.Get(id).ToExchangeUserInfo();
        }

        public PagedList<ExchangeUserInfo> FindItems(FindUsersWithPagingQuery query)
        {
            var resultList = _exchangeUserRepository.GetAll();

            if (!string.IsNullOrEmpty(query.UserName))
            {
                resultList = resultList.Where(usr =>
                    usr.Name.Equals(query.UserName, StringComparison.InvariantCultureIgnoreCase));
            }
            
            var count = resultList.Count();
            var result = resultList.OrderBy(it=>it.Id).Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize)
                .Select(usr => ExchangeUserInfo.MapToInfo(usr))
                .ToList();

            return new PagedList<ExchangeUserInfo>(result, query.PageNumber, query.PageSize, count);
        }
    }
}