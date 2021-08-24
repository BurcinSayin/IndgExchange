using System.Linq;
using Exchange.Core.ItemTransaction.Validator;
using Exchange.Core.Shared;
using Exchange.Domain.Common.Response;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ItemTransaction.Query;
using Exchange.Domain.ItemTransaction.Response;
using Exchange.Domain.ItemTransaction.Service;
using FluentValidation;

namespace Exchange.Core.ItemTransaction.Service
{
    public class ItemTransactionReadService:IItemTransactionReadService
    {
        private IItemTransactionRepository _transactionRepository;

        public ItemTransactionReadService(IItemTransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }


        public ItemTransactionInfo GetItemTransaction(GetItemTransactionQuery query)
        {
            GetItemTransactionQueryValidator validator = new GetItemTransactionQueryValidator();
            validator.ValidateAndThrow(query);
            
            return _transactionRepository.Get(query.ItemTransactionId).ToItemTransactionInfo();
        }

        public PagedList<ItemTransactionInfo> GetItemTransactions(GetItemTransactionsWithPagingQuery query)
        {
            GetItemTransactionsWithPagingQueryValidator validator = new GetItemTransactionsWithPagingQueryValidator();
            validator.ValidateAndThrow(query);

            var fullData = _transactionRepository.GetAll();

            if (query.GivingUserId.HasValue)
            {
                fullData = fullData.Where(tr => tr.GivingUserId == query.GivingUserId);
            }
            
            if (query.TakingUserId.HasValue)
            {
                fullData = fullData.Where(tr => tr.TakingUserId == query.TakingUserId.Value);
            }
            if (query.TakenItemId.HasValue)
            {
                fullData = fullData.Where(tr => tr.TakenItemId == query.TakenItemId.Value);
            }
            if (query.ExchangedItemId.HasValue)
            {
                fullData = fullData.Where(tr => tr.ExchangedItemId == query.ExchangedItemId.Value);
            }
            
            var count = fullData.Count();
            var result = fullData.OrderBy(it=>it.Id).Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(tr =>ItemTransactionInfo.MapToInfo(tr))
                .ToList();

            return new PagedList<ItemTransactionInfo>(result, query.PageNumber, query.PageSize, count);
        }
    }
}