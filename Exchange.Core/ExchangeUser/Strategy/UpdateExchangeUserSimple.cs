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
            throw new System.NotImplementedException();
        }
    }
}