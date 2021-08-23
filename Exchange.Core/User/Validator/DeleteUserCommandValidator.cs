using Exchange.Domain.User.Command;
using FluentValidation;

namespace Exchange.Core.User.Validator
{
    public class DeleteUserCommandValidator:AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(command => command.UserId).GreaterThan(0);
        }
        
    }
}