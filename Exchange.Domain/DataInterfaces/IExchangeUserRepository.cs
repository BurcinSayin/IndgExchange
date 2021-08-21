using System.Linq;

namespace Exchange.Domain.DataInterfaces
{
    public interface IExchangeUserRepository
    {
        IQueryable<ExchangeUser> GetAll();
        ExchangeUser Get(int userId);
        ExchangeUser Add(ExchangeUser toAdd);
        bool Delete(int userId);
        ExchangeUser Update(ExchangeUser toUpdate);
        ExchangeUser FindById(int userId, IDataTransaction transaction);
        
        IDataTransaction BeginTransaction();
    }
}