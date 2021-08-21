using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Domain.Strategy
{
    public interface ICreateExchangeUserStategy
    {
        ExchangeUser Create(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,
            CreateExchangeUserCommand command);
    }
}