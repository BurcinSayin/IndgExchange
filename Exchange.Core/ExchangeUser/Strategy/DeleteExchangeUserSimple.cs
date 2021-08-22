﻿using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ExchangeUser.Command;
using Exchange.Domain.ExchangeUser.Strategy;

namespace Exchange.Core.ExchangeUser.Strategy
{
    public class DeleteExchangeUserSimple:IDeleteExchangeUserStrategy
    {
        public bool Delete(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,
            DeleteExchangeUserCommand command)
        {
            bool retVal = exchangeUserRepository.Delete(command.ExchangeUserId);

            if (!retVal)
            {
                throw new NotFoundException("Exchange User Not Found.");
            }

            return true;
        }
    }
}