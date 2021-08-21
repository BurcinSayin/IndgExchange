using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;

namespace Exchange.Domain.ExchangeUser.Strategy
{
    public interface ICreateExchangeUserStategy
    {
        Entity.ExchangeUser Create(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,
            CreateExchangeUserCommand command);
    }
}