using Exchange.Core.ItemTransaction.Validator;
using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.ItemTransaction.Command;
using Exchange.Domain.ItemTransaction.Response;
using Exchange.Domain.ItemTransaction.Service;
using Exchange.Domain.ItemTransaction.Strategy;
using FluentValidation;

namespace Exchange.Core.ItemTransaction.Service
{
    public class ItemTransactionWriteService:IItemTransactionWriteService
    {
        private IItemTransactionRepository _transactionRepository;
        private IItemRepository _itemRepository;
        private IUserRepository _userRepository;
        
        private ICreateItemTransactionStrategy _strategy;

        public ItemTransactionWriteService(ICreateItemTransactionStrategy strategy, IItemRepository itemRepository, 
            IUserRepository userRepository,
            IItemTransactionRepository transactionRepository)
        {
            _strategy = strategy;
            _transactionRepository = transactionRepository;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
        }

        public ItemTransactionInfo CreateItemTransaction(CreateItemTransactionCommand command)
        {
            CreateItemTransactionCommandValidator validator = new CreateItemTransactionCommandValidator();
            validator.ValidateAndThrow(command);
            
            return _strategy.Create(_itemRepository,_userRepository,_transactionRepository,command).ToItemTransactionInfo();
        }
    }
}