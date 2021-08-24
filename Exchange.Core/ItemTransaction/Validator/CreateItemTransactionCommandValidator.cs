using Exchange.Core.Shared;
using Exchange.Domain.ItemTransaction.Command;
using FluentValidation;

namespace Exchange.Core.ItemTransaction.Validator
{
    public class CreateItemTransactionCommandValidator:AbstractExchangeValidator<CreateItemTransactionCommand>
    {
        public CreateItemTransactionCommandValidator()
        {
            RuleFor(command => command.TakenItemId).NotNull().GreaterThan(0);
            RuleFor(command => command.TakingUserId).NotNull().GreaterThan(0);
            RuleFor(command => command.ExchangedItemId).Custom((i, context) =>
            {
                if (i.HasValue)
                {
                    if (i.Value <= 0)
                    {
                        context.AddFailure("ExchangedItemId should be greater than 0 if not null");
                    }
                }
            });
            RuleFor(command => command.GivingUserId).Custom((i, context) =>
            {
                if (i.HasValue)
                {
                    if (i.Value <= 0)
                    {
                        context.AddFailure("GivingUserId should be greater than 0 if not null");
                    }
                }
            });
        }
    }
}