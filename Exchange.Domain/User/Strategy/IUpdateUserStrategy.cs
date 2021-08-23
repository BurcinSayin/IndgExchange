using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Command;

namespace Exchange.Domain.User.Strategy
{
    public interface IUpdateUserStrategy
    {
        Entity.User Update(IItemRepository itemRepository, IUserRepository userRepository,
            UpdateUserCommand command);
    }
}