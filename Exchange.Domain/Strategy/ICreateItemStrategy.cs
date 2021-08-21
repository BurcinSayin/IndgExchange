using System;
using System.Collections.Generic;
using System.Text;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Domain.Strategy
{
    public interface ICreateItemStrategy
    {
        Item Create(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,CreateItemCommand command);
    }
}
