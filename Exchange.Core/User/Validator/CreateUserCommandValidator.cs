using Exchange.Domain.User.Command;
using FluentValidation;

namespace Exchange.Core.User.Validator
{
    public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(command => command.UserName).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}