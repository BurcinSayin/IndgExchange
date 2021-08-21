using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;
using Exchange.Domain.Strategy;
using Exchange.Services.ConcreteStrategy;

namespace Exchange.Services
{
    public class ExchangeUserWriteService:IExchangeUserWriteService
    {
        private IExchangeUserRepository _exchangeUserRepository;
        private IItemRepository _itemRepository;
        private ICreateExchangeUserStategy creator;

        public ExchangeUserWriteService(IItemRepository itemRepository,IExchangeUserRepository userRepository)
        {
            _exchangeUserRepository = userRepository;
            _itemRepository = itemRepository;
            creator = new CreateExchangeUserSimple();
        }


        public ExchangeUserInfo CreateExchangeUser(CreateExchangeUserCommand command)
        {
            return creator.Create(_itemRepository, _exchangeUserRepository, command).ToExchangeUserInfo();
        }
    }
}