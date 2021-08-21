﻿using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;
using Exchange.Domain.Strategy;
using Exchange.Domain.Strategy.Item;

namespace Exchange.Services.ConcreteStrategy
{
    class CreateItemWithTransaction:ICreateItemStrategy
    {
        public Item Create(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,
            CreateItemCommand command)
        {
            var transaction = itemRepository.BeginTransaction();

            ExchangeUser itemOwner = null;
            if (command.OwnerId.HasValue)
            {
                itemOwner = exchangeUserRepository.FindById(command.OwnerId.Value, transaction);
            }

            Item toCreate = new Item()
            {
                Holder = itemOwner,
                ItemName = command.ItemName
            };

            var retVal = itemRepository.Add(toCreate);

            transaction.Commit();

            return retVal;
        }
    }
}
