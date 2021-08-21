﻿using Exchange.Domain.Model;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Domain.ServiceInterfaces
{
    public interface IExchangeUserWriteService
    {
        ExchangeUserInfo CreateExchangeUser(CreateExchangeUserCommand command);
        ExchangeUserInfo UpdateExchangeUser(UpdateExchangeUserCommand command);
        void DeleteExchangeUser(DeleteExchangeUserCommand command);
    }
}