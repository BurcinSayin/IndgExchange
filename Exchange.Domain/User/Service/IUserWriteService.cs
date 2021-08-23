using Exchange.Domain.User.Command;
using Exchange.Domain.User.Response;

namespace Exchange.Domain.User.Service
{
    public interface IUserWriteService
    {
        UserInfo CreateUser(CreateUserCommand command);
        UserInfo UpdateUser(UpdateUserCommand command);
        void DeleteUser(DeleteUserCommand command);
    }
}