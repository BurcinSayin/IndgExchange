using Exchange.Core.Shared;
using Exchange.Core.User.Validator;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.User.Command;
using Exchange.Domain.User.Response;
using Exchange.Domain.User.Service;
using FluentValidation;

namespace Exchange.Core.User.Service
{
    public class UserWriteService:IUserWriteService
    {
        private IUserRepository _userRepository;
        private IItemRepository _itemRepository;

        private UserWriteStrategySet _writeStrategySet;

        public UserWriteService(UserWriteStrategySet strategySet, IItemRepository itemRepository,IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _itemRepository = itemRepository;
            _writeStrategySet = strategySet;
        }


        public UserInfo CreateUser(CreateUserCommand command)
        {
            CreateUserCommandValidator validator = new CreateUserCommandValidator();
            validator.ValidateAndThrow(command);
            
            return _writeStrategySet.Create(_itemRepository, _userRepository, command).ToUserInfo();
        }

        public UserInfo UpdateUser(UpdateUserCommand command)
        {
            UpdateUserCommandValidator validator = new UpdateUserCommandValidator();
            validator.ValidateAndThrow(command);

            return _writeStrategySet.Update(_itemRepository, _userRepository, command).ToUserInfo();
        }

        public void DeleteUser(DeleteUserCommand command)
        {
            DeleteUserCommandValidator validator = new DeleteUserCommandValidator();
            validator.ValidateAndThrow(command);
            
            _writeStrategySet.Delete(_itemRepository, _userRepository, command);
        }
    }
}