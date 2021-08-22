using Exchange.Domain.ExchangeUser.Command;
using FluentValidation;

namespace Exchange.Core.ExchangeUser.Validator
{
    public class DeleteExchangeUserCommandValidator:AbstractValidator<DeleteExchangeUserCommand>
    {
        public DeleteExchangeUserCommandValidator()
        {
            RuleFor(command => command.ExchangeUserId).GreaterThan(0);
        }
        
    }
}