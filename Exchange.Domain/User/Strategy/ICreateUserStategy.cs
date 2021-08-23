using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Command;

namespace Exchange.Domain.User.Strategy
{
    public interface ICreateUserStrategy
    {
        Entity.User Create(IItemRepository itemRepository, IUserRepository userRepository,
            CreateUserCommand command);
    }
}