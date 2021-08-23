using Exchange.Core.Shared;
using Exchange.Domain.Item.Command;
using FluentValidation;

namespace Exchange.Core.Item.Validator
{
    public class UpdateItemCommandValidator:AbstractExchangeValidator<UpdateItemCommand>
    {
        public UpdateItemCommandValidator()
        {
            RuleFor(command => command.ItemId).GreaterThan(0);
            RuleFor(command => command.HolderId).Custom((i, context) =>
            {
                if (i.HasValue)
                {
                    if (i.Value <= 0)
                    {
                        context.AddFailure("Holder Id should be greater than 0 if not null");
                    }
                }

            });
        }
    }
}