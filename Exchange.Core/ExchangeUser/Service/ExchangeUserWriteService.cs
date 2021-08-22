using Exchange.Core.ExchangeUser.Strategy;
using Exchange.Core.ExchangeUser.Validator;
using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;
using Exchange.Domain.ExchangeUser.Response;
using Exchange.Domain.ExchangeUser.Service;
using Exchange.Domain.ExchangeUser.Strategy;
using FluentValidation;

namespace Exchange.Core.ExchangeUser.Service
{
    public class ExchangeUserWriteService:IExchangeUserWriteService
    {
        private IExchangeUserRepository _exchangeUserRepository;
        private IItemRepository _itemRepository;

        private ExchangeUserWriteStrategySet _writeStrategySet;

        public ExchangeUserWriteService(ExchangeUserWriteStrategySet strategySet, IItemRepository itemRepository,IExchangeUserRepository userRepository)
        {
            _exchangeUserRepository = userRepository;
            _itemRepository = itemRepository;
            _writeStrategySet = strategySet;
        }


        public ExchangeUserInfo CreateExchangeUser(CreateExchangeUserCommand command)
        {
            CreateExchangeUserCommandValidator validator = new CreateExchangeUserCommandValidator();
            validator.ValidateAndThrow(command);
            
            return _writeStrategySet.Create(_itemRepository, _exchangeUserRepository, command).ToExchangeUserInfo();
        }

        public ExchangeUserInfo UpdateExchangeUser(UpdateExchangeUserCommand command)
        {
            UpdateExchangeUserCommandValidator validator = new UpdateExchangeUserCommandValidator();
            validator.ValidateAndThrow(command);

            return _writeStrategySet.Update(_itemRepository, _exchangeUserRepository, command).ToExchangeUserInfo();
        }

        public void DeleteExchangeUser(DeleteExchangeUserCommand command)
        {
            DeleteExchangeUserCommandValidator validator = new DeleteExchangeUserCommandValidator();
            validator.ValidateAndThrow(command);
            
            _writeStrategySet.Delete(_itemRepository, _exchangeUserRepository, command);
        }
    }
}