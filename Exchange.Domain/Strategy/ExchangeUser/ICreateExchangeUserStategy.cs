using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Domain.Strategy.ExchangeUser
{
    public interface ICreateExchangeUserStategy
    {
        DataInterfaces.ExchangeUser Create(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,
            CreateExchangeUserCommand command);
    }
}