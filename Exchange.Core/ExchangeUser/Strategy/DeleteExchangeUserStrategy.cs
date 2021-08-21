using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;
using Exchange.Domain.ExchangeUser.Strategy;

namespace Exchange.Core.ExchangeUser.Strategy
{
    public class DeleteExchangeUserStrategy:IDeleteExchangeUserStrategy
    {
        public bool Delete(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,
            DeleteExchangeUserCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}