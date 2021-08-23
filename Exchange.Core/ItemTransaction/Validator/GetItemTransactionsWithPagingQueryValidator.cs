using Exchange.Core.Shared;
using Exchange.Domain.ItemTransaction.Query;
using FluentValidation;

namespace Exchange.Core.ItemTransaction.Validator
{
    public class GetItemTransactionsWithPagingQueryValidator:AbstractExchangeValidator<GetItemTransactionsWithPagingQuery>
    {
        public GetItemTransactionsWithPagingQueryValidator()
        {
            RuleFor(query => query.PageNumber).GreaterThan(0);
            RuleFor(query => query.PageSize).GreaterThan(0);
            RuleFor(query => query.GivingUserId).Custom((i, context) =>
            {
                if (i.HasValue)
                {
                    if (i.Value <= 0)
                    {
                        context.AddFailure("GivingUserId should be greater than 0 if not null");
                    }
                }
            });
            RuleFor(query => query.TakingUserId).Custom((i, context) =>
            {
                if (i.HasValue)
                {
                    if (i.Value <= 0)
                    {
                        context.AddFailure("TakingUserId should be greater than 0 if not null");
                    }
                }
            });
            RuleFor(query => query.GivenItemId).Custom((i, context) =>
            {
                if (i.HasValue)
                {
                    if (i.Value <= 0)
                    {
                        context.AddFailure("GivenItemId should be greater than 0 if not null");
                    }
                }
            });
            RuleFor(query => query.ExchangedItemId).Custom((i, context) =>
            {
                if (i.HasValue)
                {
                    if (i.Value <= 0)
                    {
                        context.AddFailure("ExchangedItemId should be greater than 0 if not null");
                    }
                }
            });
        }
    }
}