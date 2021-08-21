using System.Data;
using System.Linq;
using Exchange.Domain.DataInterfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Exchange.Data.Sqlite
{
    public class ItemRepository:IItemRepository
    {
        private ExchangeDataContext _context;
        
        public ItemRepository(ExchangeDataContext context)
        {
            _context = context;
            _context.Database?.EnsureCreated();
        }
        
        public IQueryable<Item> GetAll()
        {
            return _context.Items.AsNoTracking();
        }

        public Item Get(int itemId)
        {
            return _context.Items.AsNoTracking().FirstOrDefault(item => item.Id == itemId);
        }

        public Item Add(Item toAdd)
        {
            _context.Items.Add(toAdd);
            _context.SaveChanges();
            return toAdd;
        }

        public bool Delete(int itemId)
        {
            var toDelete = _context.Items.FirstOrDefault(item => item.Id == itemId);
            if (toDelete != null)
            {
                var res = _context.Items.Remove(toDelete);
                return (_context.SaveChanges() > 0);
            }

            return false;
        }

        public Item Update(Item toUpdate)
        {
            _context.Update(toUpdate);
            _context.SaveChanges();
            return toUpdate;
        }

        // public bool MoveItem(int fromId, int toId, int itemId)
        // {
        //     var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
        //
        //
        //     
        //      
        //     _context.Database.ExecuteSqlRaw(
        //         "UPDATE Items SET HolderId = {0} WHERE Id = {1} AND HolderId = {2};",toId,fromId,itemId);
        //     
        //     
        //     transaction.Commit();
        //
        //     return true;
        // }

        public IDataTransaction BeginTransaction()
        {
            return new ExchangeSqliteTransaction(_context.Database.BeginTransaction(IsolationLevel.RepeatableRead));
        }

        public Item FindById(int itemId, IDataTransaction transaction)
        {
            return _context.Items.FirstOrDefault(it => it.Id == itemId);
        }
    }
}