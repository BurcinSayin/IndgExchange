using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Command;
using Exchange.Domain.User.Strategy;

namespace Exchange.Core.User.Service
{
    public class UserWriteStrategySet
    {
        private ICreateUserStrategy createStrategy;
        private IUpdateUserStrategy updateStrategy;
        private IDeleteUserStrategy deleteStrategy;

        public UserWriteStrategySet(ICreateUserStrategy createStrategy, IUpdateUserStrategy updateStrategy, IDeleteUserStrategy deleteStrategy)
        {
            this.createStrategy = createStrategy;
            this.updateStrategy = updateStrategy;
            this.deleteStrategy = deleteStrategy;
        }
        
        public Domain.User.Entity.User Create(IItemRepository itemRepository, IUserRepository userRepository, CreateUserCommand createCommand)
        {
            return createStrategy.Create(itemRepository, userRepository, createCommand);
        }

        public Domain.User.Entity.User Update(IItemRepository itemRepository, IUserRepository userRepository, UpdateUserCommand command)
        {
            return updateStrategy.Update(itemRepository, userRepository, command);
        }

        public bool Delete(IItemRepository itemRepository, IUserRepository userRepository, DeleteUserCommand command)
        {
            return deleteStrategy.Delete(itemRepository, userRepository, command);
        }
    }
}