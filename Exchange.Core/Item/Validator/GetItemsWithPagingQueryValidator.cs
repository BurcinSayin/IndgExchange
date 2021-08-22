using Exchange.Domain.Item.Query;
using FluentValidation;

namespace Exchange.Core.Item.Validator
{
    public class GetItemsWithPagingQueryValidator:AbstractValidator<GetItemsWithPagingQuery>
    {
        public GetItemsWithPagingQueryValidator()
        {
            RuleFor(query => query.PageNumber).GreaterThan(0);
            RuleFor(query => query.PageSize).GreaterThan(0);
            RuleFor(query => query.OwnerId).Custom((i, context) =>
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