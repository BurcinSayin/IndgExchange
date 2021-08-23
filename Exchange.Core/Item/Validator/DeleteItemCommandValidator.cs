using Exchange.Core.Shared;
using Exchange.Domain.Item.Command;
using FluentValidation;

namespace Exchange.Core.Item.Validator
{
    public class DeleteItemCommandValidator:AbstractExchangeValidator<DeleteItemCommand>
    {

        public DeleteItemCommandValidator()
        {
            RuleFor(command => command.ItemId).GreaterThan(0);
        }
        
    }
}