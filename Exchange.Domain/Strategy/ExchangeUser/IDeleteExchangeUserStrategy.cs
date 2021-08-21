using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Domain.Strategy.ExchangeUser
{
    public interface IDeleteExchangeUserStrategy
    {
        bool Delete(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository, DeleteExchangeUserCommand command);
    }
}