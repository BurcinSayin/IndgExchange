using Exchange.Core.Item.Strategy;
using Exchange.Core.Item.Validator;
using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Response;
using Exchange.Domain.Item.Service;
using Exchange.Domain.Item.Strategy;
using FluentValidation;

namespace Exchange.Core.Item.Service
{
    public class ItemWriteService:IItemWriteService
    {
        private IItemRepository _itemRepository;
        private IUserRepository _userRepository;

        // private ICreateItemStrategy createStrategy;
        // private IUpdateItemStrategy updateStratgy;
        // private IDeleteItemStrategy deleteStrategy;

        private ItemWriteStrategySet _writeStrategySet;

        public ItemWriteService(ItemWriteStrategySet strategySet,IItemRepository itemRepository, IUserRepository userRepository)
        {
            _itemRepository = itemRepository;
            _userRepository = userRepository;
            // createStrategy = new CreateItemWithTransaction();
            // updateStratgy = new UpdateItemWithTransaction();
            // deleteStrategy = new DeleteItemSimple();

            _writeStrategySet = strategySet;
        }

        public ItemInfo CreateItem(CreateItemCommand createCommand)
        {
            CreateItemCommandValidator validator = new CreateItemCommandValidator();
            validator.ValidateAndThrow(createCommand);
            
            return _writeStrategySet.Create(_itemRepository,_userRepository, createCommand).ToItemInfo();
        }

        public ItemInfo UpdateItem(UpdateItemCommand command)
        {
            UpdateItemCommandValidator validator = new UpdateItemCommandValidator();
            validator.ValidateAndThrow(command);
            
            return _writeStrategySet.Update(_itemRepository,_userRepository, command).ToItemInfo();
        }

        public void DeleteItem(DeleteItemCommand command)
        {
            DeleteItemCommandValidator validator = new DeleteItemCommandValidator();
            validator.ValidateAndThrow(command);
            
            _writeStrategySet.Delete(_itemRepository, _userRepository, command);
        }
    }


}