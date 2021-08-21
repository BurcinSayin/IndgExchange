using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;
using Exchange.Domain.Strategy;
using Exchange.Domain.Strategy.ExchangeUser;

namespace Exchange.Services.ConcreteStrategy
{
    public class CreateExchangeUserSimple:ICreateExchangeUserStategy
    {
        public ExchangeUser Create(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,
            CreateExchangeUserCommand command)
        {
            ExchangeUser toCreate = new ExchangeUser()
            {
                Name = command.UserName
            };

            return exchangeUserRepository.Add(toCreate);
            
        }
    }
}