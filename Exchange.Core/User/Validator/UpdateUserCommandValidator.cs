using Exchange.Domain.User.Command;
using FluentValidation;

namespace Exchange.Core.User.Validator
{
    public class UpdateUserCommandValidator:AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(command => command.UserId).GreaterThan(0);
        }
        
    }
}