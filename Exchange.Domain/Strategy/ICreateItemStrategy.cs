using System;
using System.Collections.Generic;
using System.Text;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ServiceInterfaces.Commands;

namespace Exchange.Domain.Strategy
{
    public interface ICreateItemStrategy
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemRepository"></param>
        /// <param name="exchangeUserRepository"></param>
        /// <param name="command">Create command parameters</param>
        /// <returns>Created Item</returns>
        Item CreateItem(IItemRepository itemRepository, IExchangeUserRepository exchangeUserRepository,CreateItemCommand command);
    }
}
