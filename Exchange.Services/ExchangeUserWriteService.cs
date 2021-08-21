using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;
using Exchange.Domain.Strategy;
using Exchange.Domain.Strategy.ExchangeUser;
using Exchange.Domain.Strategy.Item;
using Exchange.Services.ConcreteStrategy;

namespace Exchange.Services
{
    public class ExchangeUserWriteService:IExchangeUserWriteService
    {
        private IExchangeUserRepository _exchangeUserRepository;
        private IItemRepository _itemRepository;

        private ICreateExchangeUserStategy createStrategy;
        private IUpdateExchangeUserStrategy updateStratgy;
        private IDeleteExchangeUserStrategy deleteStrategy;

        public ExchangeUserWriteService(IItemRepository itemRepository,IExchangeUserRepository userRepository)
        {
            _exchangeUserRepository = userRepository;
            _itemRepository = itemRepository;
            createStrategy = new CreateExchangeUserSimple();
        }


        public ExchangeUserInfo CreateExchangeUser(CreateExchangeUserCommand command)
        {
            return createStrategy.Create(_itemRepository, _exchangeUserRepository, command).ToExchangeUserInfo();
        }

        public ExchangeUserInfo UpdateExchangeUser(UpdateExchangeUserCommand command)
        {
            return updateStratgy.Update(_itemRepository, _exchangeUserRepository, command).ToExchangeUserInfo();
        }

        public void DeleteExchangeUser(DeleteExchangeUserCommand command)
        {
            deleteStrategy.Delete(_itemRepository, _exchangeUserRepository, command);
        }
    }
}