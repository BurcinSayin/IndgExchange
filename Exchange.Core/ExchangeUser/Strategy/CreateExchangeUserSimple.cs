using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;
using Exchange.Domain.ExchangeUser.Entity;
using Exchange.Domain.ExchangeUser.Strategy;


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