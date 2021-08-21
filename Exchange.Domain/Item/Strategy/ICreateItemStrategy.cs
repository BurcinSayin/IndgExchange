﻿using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;

namespace Exchange.Domain.Item.Strategy
{
    public interface ICreateItemStrategy
    {
        Entity.Item Create(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,CreateItemCommand command);
    }
}
