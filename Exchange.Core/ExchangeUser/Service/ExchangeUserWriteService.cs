﻿using Exchange.Core.ExchangeUser.Strategy;
using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;
using Exchange.Domain.ExchangeUser.Response;
using Exchange.Domain.ExchangeUser.Service;
using Exchange.Domain.ExchangeUser.Strategy;

namespace Exchange.Core.ExchangeUser.Service
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
            updateStratgy = new UpdateExchangeUserSimple();
            deleteStrategy = new DeleteExchangeUserSimple();
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