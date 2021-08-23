using System.Data;
using System.Linq;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ItemTransaction.Entity;
using Microsoft.EntityFrameworkCore;

namespace Exchange.Data.Sqlite
{
    public class ItemTransactionRepository:IItemTransactionRepository
    {
        private ExchangeDataContext _context;

        public ItemTransactionRepository(ExchangeDataContext context)
        {
            _context = context;
            _context.Database?.EnsureCreated();
        }

        public IQueryable<ItemTransaction> GetAll()
        {
            return _context.ItemTransactions.AsNoTracking();
        }

        public ItemTransaction Get(int transactionId)
        {
            return _context.ItemTransactions.AsNoTracking().FirstOrDefault(tran => tran.Id == transactionId);
        }

        public ItemTransaction Add(ItemTransaction toAdd)
        {
            _context.ItemTransactions.Add(toAdd);
            _context.SaveChanges();
            return toAdd;
        }

        public bool Delete(int itemId)
        {
            var toDelete = _context.ItemTransactions.FirstOrDefault(item => item.Id == itemId);
            if (toDelete != null)
            {
                var res = _context.ItemTransactions.Remove(toDelete);
                return (_context.SaveChanges() > 0);
            }

            return false;
        }

        public ItemTransaction Update(ItemTransaction toUpdate)
        {
            _context.ItemTransactions.Update(toUpdate);
            _context.SaveChanges();
            return toUpdate;
        }

        public IDataTransaction BeginTransaction()
        {
            return new ExchangeSqliteTransaction(_context.Database.BeginTransaction(IsolationLevel.RepeatableRead));
        }

        public ItemTransaction FindById(int transactionId, IDataTransaction transaction)
        {
            return _context.ItemTransactions.FirstOrDefault(it => it.Id == transactionId);
        }
    }
}