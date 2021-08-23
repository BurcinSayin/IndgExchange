using Exchange.Domain.ItemTransaction.Command;
using Exchange.Domain.ItemTransaction.Response;

namespace Exchange.Domain.ItemTransaction.Service
{
    public interface IItemTransactionWriteService
    {
        ItemTransactionInfo CreateItemTransaction(CreateItemTransactionCommand command);
    }
}