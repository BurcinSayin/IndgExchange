using System.Security.Cryptography;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Command;
using Exchange.Domain.User.Strategy;

namespace Exchange.Core.User.Strategy
{
    public class CreateUserSimple:ICreateUserStrategy
    {
        public Domain.User.Entity.User Create(IItemRepository itemRepository, IUserRepository userRepository,
            CreateUserCommand command)
        {
            Domain.User.Entity.User toCreate = new Domain.User.Entity.User()
            {
                Name = command.UserName,
                Password = command.Password
            };

            return userRepository.Add(toCreate);
            
        }
    }
}