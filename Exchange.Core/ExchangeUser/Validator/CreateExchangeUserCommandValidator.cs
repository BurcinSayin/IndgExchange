using Exchange.Domain.ExchangeUser.Command;
using FluentValidation;

namespace Exchange.Core.ExchangeUser.Validator
{
    public class CreateExchangeUserCommandValidator:AbstractValidator<CreateExchangeUserCommand>
    {
        public CreateExchangeUserCommandValidator()
        {
            RuleFor(command => command.UserName).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}