using Exchange.Domain.ExchangeUser.Command;
using FluentValidation;

namespace Exchange.Core.ExchangeUser.Validator
{
    public class UpdateExchangeUserCommandValidator:AbstractValidator<UpdateExchangeUserCommand>
    {
        public UpdateExchangeUserCommandValidator()
        {
            RuleFor(command => command.ExchangeUserId).GreaterThan(0);
        }
        
    }
}