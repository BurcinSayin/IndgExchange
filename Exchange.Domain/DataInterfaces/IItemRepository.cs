using System.Linq;

namespace Exchange.Domain.DataInterfaces
{
    public interface IItemRepository
    {
        IQueryable<Item.Entity.Item> GetAll();
        Item.Entity.Item Get(int itemId);
        Item.Entity.Item Add(Item.Entity.Item toAdd);
        bool Delete(int itemId);
        Item.Entity.Item Update(Item.Entity.Item toUpdate);
        
        IDataTransaction BeginTransaction();
        Item.Entity.Item FindById(int commandItemId, IDataTransaction transaction);
    }
}