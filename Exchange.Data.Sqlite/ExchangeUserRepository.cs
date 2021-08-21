using System.Data;
using System.Linq;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Entity;
using Microsoft.EntityFrameworkCore;

namespace Exchange.Data.Sqlite
{
    public class ExchangeUserRepository:IExchangeUserRepository
    {
        private ExchangeDataContext _context;
        
        public ExchangeUserRepository(ExchangeDataContext context)
        {
            _context = context;
            _context.Database?.EnsureCreated();
        }
        
        public IQueryable<ExchangeUser> GetAll()
        {
            return _context.ExchangeUsers.AsNoTracking();
        }

        public ExchangeUser Get(int userId)
        {
            return _context.ExchangeUsers.AsNoTracking().FirstOrDefault(usr => usr.Id == userId);
        }

        public ExchangeUser Add(ExchangeUser toAdd)
        {
            _context.ExchangeUsers.Add(toAdd);
            _context.SaveChanges();
            return toAdd;
        }

        public bool Delete(int userId)
        {
            var toDelete = _context.ExchangeUsers.FirstOrDefault(usr => usr.Id == userId);
            if (toDelete != null)
            {
                var res = _context.ExchangeUsers.Remove(toDelete);
                return (_context.SaveChanges() > 0);
            }

            return false;
        }

        //TODO: may need to fix this
        public ExchangeUser Update(ExchangeUser toUpdate)
        {
            _context.Update(toUpdate);
            _context.SaveChanges();
            return toUpdate;
        }

        public ExchangeUser FindById(int userId, IDataTransaction transaction)
        {
            return _context.ExchangeUsers.FirstOrDefault(usr => usr.Id == userId);
        }

        public IDataTransaction BeginTransaction()
        {
            return new ExchangeSqliteTransaction(_context.Database.BeginTransaction(IsolationLevel.RepeatableRead));
        }
    }
}