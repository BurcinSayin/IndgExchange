using System.Linq;

namespace Exchange.Domain.DataInterfaces
{
    public interface IExchangeUserRepository
    {
        IQueryable<ExchangeUser.Entity.ExchangeUser> GetAll();
        ExchangeUser.Entity.ExchangeUser Get(int userId);
        ExchangeUser.Entity.ExchangeUser Add(ExchangeUser.Entity.ExchangeUser toAdd);
        bool Delete(int userId);
        ExchangeUser.Entity.ExchangeUser Update(ExchangeUser.Entity.ExchangeUser toUpdate);
        ExchangeUser.Entity.ExchangeUser FindById(int userId, IDataTransaction transaction);
        
        IDataTransaction BeginTransaction();
    }
}