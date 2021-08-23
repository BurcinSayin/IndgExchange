using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ItemTransaction.Command;
using Exchange.Domain.ItemTransaction.Response;

namespace Exchange.Domain.ItemTransaction.Strategy
{
    public interface ICreateItemTransactionStrategy
    {
        Entity.ItemTransaction Create(IItemRepository itemRepository, IUserRepository userRepository, 
            IItemTransactionRepository transactionRepository,
                CreateItemTransactionCommand command);
    }
}