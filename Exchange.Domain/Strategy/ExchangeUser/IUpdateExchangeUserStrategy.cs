using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Domain.Strategy.ExchangeUser
{
    public interface IUpdateExchangeUserStrategy
    {
        DataInterfaces.ExchangeUser Update(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,
            UpdateExchangeUserCommand command);
    }
}