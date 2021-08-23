using System.Data;
using System.Linq;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Entity;
using Microsoft.EntityFrameworkCore;

namespace Exchange.Data.Sqlite
{
    public class UserRepository:IUserRepository
    {
        private ExchangeDataContext _context;
        
        public UserRepository(ExchangeDataContext context)
        {
            _context = context;
            _context.Database?.EnsureCreated();
        }
        
        public IQueryable<User> GetAll()
        {
            return _context.Users.AsNoTracking();
        }

        public User Get(int userId)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(usr => usr.Id == userId);
        }

        public User Add(User toAdd)
        {
            _context.Users.Add(toAdd);
            _context.SaveChanges();
            return toAdd;
        }

        public bool Delete(int userId)
        {
            var toDelete = _context.Users.FirstOrDefault(usr => usr.Id == userId);
            if (toDelete != null)
            {
                var res = _context.Users.Remove(toDelete);
                return (_context.SaveChanges() > 0);
            }

            return false;
        }

        //TODO: may need to fix this
        public User Update(User toUpdate)
        {
            _context.Update(toUpdate);
            _context.SaveChanges();
            return toUpdate;
        }

        public User FindById(int userId, IDataTransaction transaction)
        {
            return _context.Users.FirstOrDefault(usr => usr.Id == userId);
        }

        public IDataTransaction BeginTransaction()
        {
            return new ExchangeSqliteTransaction(_context.Database.BeginTransaction(IsolationLevel.RepeatableRead));
        }
    }
}