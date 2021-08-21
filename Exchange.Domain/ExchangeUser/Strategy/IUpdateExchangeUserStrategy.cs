using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;

namespace Exchange.Domain.ExchangeUser.Strategy
{
    public interface IUpdateExchangeUserStrategy
    {
        Entity.ExchangeUser Update(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,
            UpdateExchangeUserCommand command);
    }
}