using Exchange.Domain.Common.Response;
using Exchange.Domain.ItemTransaction.Query;
using Exchange.Domain.ItemTransaction.Response;

namespace Exchange.Domain.ItemTransaction.Service
{
    public interface IItemTransactionReadService
    {
        ItemTransactionInfo GetItemTransaction(GetItemTransactionQuery query);
        PagedList<ItemTransactionInfo> GetTransactionItems(GetItemTransactionsWithPagingQuery query);
    }
}