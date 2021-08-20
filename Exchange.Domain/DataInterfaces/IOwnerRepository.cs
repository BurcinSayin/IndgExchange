using System.Linq;

namespace Exchange.Domain.DataInterfaces
{
    public interface IOwnerRepository
    {
        IQueryable<Owner> GetAll();
        Owner Get(int ownerId);
        Owner Add(Owner toAdd);
        bool Delete(int ownerId);
        Owner Update(Owner toUpdate);
    }
}