using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;

namespace Exchange.Domain.ExchangeUser.Strategy
{
    public interface IDeleteExchangeUserStrategy
    {
        bool Delete(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository, DeleteExchangeUserCommand command);
    }
}