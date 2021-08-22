using Exchange.Core.ExchangeUser.Validator;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;
using Exchange.Domain.ExchangeUser.Strategy;
using Exchange.Domain.Item.Command;
using FluentValidation;

namespace Exchange.Core.ExchangeUser.Service
{
    public class ExchangeUserWriteStrategySet
    {
        private ICreateExchangeUserStategy createStrategy;
        private IUpdateExchangeUserStrategy updateStrategy;
        private IDeleteExchangeUserStrategy deleteStrategy;

        public ExchangeUserWriteStrategySet(ICreateExchangeUserStategy createStrategy, IUpdateExchangeUserStrategy updateStrategy, IDeleteExchangeUserStrategy deleteStrategy)
        {
            this.createStrategy = createStrategy;
            this.updateStrategy = updateStrategy;
            this.deleteStrategy = deleteStrategy;
        }
        
        public Domain.ExchangeUser.Entity.ExchangeUser Create(IItemRepository itemRepository, IExchangeUserRepository userRepository, CreateExchangeUserCommand createCommand)
        {
            return createStrategy.Create(itemRepository, userRepository, createCommand);
        }

        public Domain.ExchangeUser.Entity.ExchangeUser Update(IItemRepository itemRepository, IExchangeUserRepository userRepository, UpdateExchangeUserCommand command)
        {
            return updateStrategy.Update(itemRepository, userRepository, command);
        }

        public bool Delete(IItemRepository itemRepository, IExchangeUserRepository userRepository, DeleteExchangeUserCommand command)
        {
            return deleteStrategy.Delete(itemRepository, userRepository, command);
        }
    }
}