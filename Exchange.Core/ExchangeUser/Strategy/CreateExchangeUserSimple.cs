using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;
using Exchange.Domain.ExchangeUser.Strategy;

namespace Exchange.Core.ExchangeUser.Strategy
{
    public class CreateExchangeUserSimple:ICreateExchangeUserStategy
    {
        public Domain.ExchangeUser.Entity.ExchangeUser Create(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,
            CreateExchangeUserCommand command)
        {
            Domain.ExchangeUser.Entity.ExchangeUser toCreate = new Domain.ExchangeUser.Entity.ExchangeUser()
            {
                Name = command.UserName
            };

            return exchangeUserRepository.Add(toCreate);
            
        }
    }
}