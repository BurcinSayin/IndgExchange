using System.Linq;

namespace Exchange.Domain.DataInterfaces
{
    public interface IItemRepository
    {
        IQueryable<Item> GetAll();
        Item Get(int itemId);
        Item Add(Item toAdd);
        bool Delete(int itemId);
        Item Update(Item toUpdate);
        
        IDataTransaction BeginTransaction();
        Item FindById(int commandItemId, IDataTransaction transaction);
    }
}