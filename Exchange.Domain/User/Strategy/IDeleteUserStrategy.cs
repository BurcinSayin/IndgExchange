using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Command;

namespace Exchange.Domain.User.Strategy
{
    public interface IDeleteUserStrategy
    {
        bool Delete(IItemRepository itemRepository, IUserRepository userRepository, DeleteUserCommand command);
    }
}