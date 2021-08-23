using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Command;
using Exchange.Domain.User.Strategy;

namespace Exchange.Core.User.Strategy
{
    public class DeleteUserSimple:IDeleteUserStrategy
    {
        public bool Delete(IItemRepository itemRepository, IUserRepository userRepository,
            DeleteUserCommand command)
        {
            bool retVal = userRepository.Delete(command.UserId);

            if (!retVal)
            {
                throw new NotFoundException("Exchange User Not Found.");
            }

            return true;
        }
    }
}