using Exchange.Domain.User.Command;
using FluentValidation;

namespace Exchange.Core.User.Validator
{
    public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(command => command.UserName).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(command => command.Password).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}