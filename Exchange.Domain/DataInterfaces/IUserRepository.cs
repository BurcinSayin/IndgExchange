using System.Linq;
using Exchange.Domain.User.Entity;

namespace Exchange.Domain.DataInterfaces
{
    public interface IUserRepository
    {
        IQueryable<User.Entity.User> GetAll();
        User.Entity.User Get(int userId);
        User.Entity.User Add(User.Entity.User toAdd);
        bool Delete(int userId);
        User.Entity.User Update(User.Entity.User toUpdate);
        
        IDataTransaction BeginTransaction();
        User.Entity.User FindById(int userId, IDataTransaction transaction);
    }
}