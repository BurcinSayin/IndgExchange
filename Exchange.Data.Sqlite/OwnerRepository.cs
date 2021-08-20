using System.Linq;
using Exchange.Domain.DataInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Exchange.Data.Sqlite
{
    public class OwnerRepository:IOwnerRepository
    {
        private ExchangeDataContext _context;
        
        public OwnerRepository(ExchangeDataContext context)
        {
            _context = context;
            _context.Database?.EnsureCreated();
        }
        
        public IQueryable<Owner> GetAll()
        {
            return _context.Owners.AsNoTracking();
        }

        public Owner Get(int ownerId)
        {
            return _context.Owners.AsNoTracking().FirstOrDefault(owner => owner.Id == ownerId);
        }

        public Owner Add(Owner toAdd)
        {
            _context.Owners.Add(toAdd);
            _context.SaveChanges();
            return toAdd;
        }

        public bool Delete(int ownerId)
        {
            var toDelete = _context.Owners.FirstOrDefault(owner => owner.Id == ownerId);
            if (toDelete != null)
            {
                var res = _context.Owners.Remove(toDelete);
                return (_context.SaveChanges() > 0);
            }

            return false;
        }

        //TODO: may need to fix this
        public Owner Update(Owner toUpdate)
        {
            _context.Update(toUpdate);
            _context.SaveChanges();
            return toUpdate;
        }
    }
}