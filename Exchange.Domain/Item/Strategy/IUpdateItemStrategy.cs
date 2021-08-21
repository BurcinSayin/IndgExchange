﻿using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;

namespace Exchange.Domain.Item.Strategy
{
    public interface IUpdateItemStrategy
    {
        Entity.Item Update(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,UpdateItemCommand command);
    }
}