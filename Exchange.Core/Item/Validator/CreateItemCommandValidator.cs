using Exchange.Domain.Item.Command;
using FluentValidation;

namespace Exchange.Core.Item.Validator
{
    public class CreateItemCommandValidator:AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(command => command.ItemName).NotEmpty().NotNull();
            RuleFor(command => command.OwnerId).Custom((i, context) =>
            {
                if (i.HasValue)
                {
                    if (i.Value <= 0)
                    {
                        context.AddFailure("OwnerId should be greater than 0 if not null");
                    }
                }
            });
        }
    }
}