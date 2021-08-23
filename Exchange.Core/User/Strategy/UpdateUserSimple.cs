using Exchange.Core.Shared;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Command;
using Exchange.Domain.User.Strategy;

namespace Exchange.Core.User.Strategy
{
    public class UpdateUserSimple:IUpdateUserStrategy
    {
        public Domain.User.Entity.User Update(IItemRepository itemRepository, IUserRepository userRepository,
            UpdateUserCommand command)
        {
            var targetUser = userRepository.Get(command.UserId);
            if (targetUser == null)
            {
                throw new NotFoundException("Exchange User Not Found.");
            }

            targetUser.Name = command.Name;

            return userRepository.Update(targetUser);
        }
    }
}