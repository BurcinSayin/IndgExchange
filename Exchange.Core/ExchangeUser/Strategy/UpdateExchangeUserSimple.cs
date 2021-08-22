using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;
using Exchange.Domain.ExchangeUser.Strategy;

namespace Exchange.Core.ExchangeUser.Strategy
{
    public class UpdateExchangeUserSimple:IUpdateExchangeUserStrategy
    {
        public Domain.ExchangeUser.Entity.ExchangeUser Update(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,
            UpdateExchangeUserCommand command)
        {
            var targetExchangeUser = exchangeUserRepository.Get(command.ExchangeUserId);

            targetExchangeUser.Name = command.Name;

            return exchangeUserRepository.Update(targetExchangeUser);
        }
    }
}