using System.Linq;

namespace Exchange.Domain.DataInterfaces
{
    public interface IItemTransactionRepository
    {
        IQueryable<ItemTransaction.Entity.ItemTransaction> GetAll();
        ItemTransaction.Entity.ItemTransaction Get(int itemId);
        ItemTransaction.Entity.ItemTransaction Add(ItemTransaction.Entity.ItemTransaction toAdd);
        bool Delete(int itemId);
        ItemTransaction.Entity.ItemTransaction Update(ItemTransaction.Entity.ItemTransaction toUpdate);
        
        IDataTransaction BeginTransaction();
        ItemTransaction.Entity.ItemTransaction FindById(int commandItemId, IDataTransaction transaction);
    }
}