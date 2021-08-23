using Exchange.Core.Item.Validator;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Command;
using Exchange.Domain.Item.Response;
using Exchange.Domain.Item.Strategy;
using FluentValidation;

namespace Exchange.Core.Item.Service
{
    public class ItemWriteStrategySet
    {
        private ICreateItemStrategy createStrategy;
        private IUpdateItemStrategy updateStratgy;
        private IDeleteItemStrategy deleteStrategy;

        public ItemWriteStrategySet( ICreateItemStrategy createStrategy, IUpdateItemStrategy updateStratgy,IDeleteItemStrategy deleteStrategy)
        {
            this.deleteStrategy = deleteStrategy;
            this.updateStratgy = updateStratgy;
            this.createStrategy = createStrategy;
        }

        public Domain.Item.Entity.Item Create(IItemRepository itemRepository, IUserRepository userRepository, CreateItemCommand createCommand)
        {
            CreateItemCommandValidator validator = new CreateItemCommandValidator();
            validator.ValidateAndThrow(createCommand);
            
            return createStrategy.Create(itemRepository, userRepository, createCommand);
        }

        public Domain.Item.Entity.Item Update(IItemRepository itemRepository, IUserRepository userRepository, UpdateItemCommand command)
        {
            UpdateItemCommandValidator validator = new UpdateItemCommandValidator();
            validator.ValidateAndThrow(command);
            
            return updateStratgy.Update(itemRepository, userRepository, command);
        }

        public bool Delete(IItemRepository itemRepository, IUserRepository userRepository, DeleteItemCommand command)
        {
            DeleteItemCommandValidator validator = new DeleteItemCommandValidator();
            validator.ValidateAndThrow(command);
            
            return deleteStrategy.Delete(itemRepository, userRepository, command);
        }
    }
}