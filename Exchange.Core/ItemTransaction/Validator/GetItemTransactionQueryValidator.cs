using Exchange.Core.Shared;
using Exchange.Domain.ItemTransaction.Query;
using FluentValidation;

namespace Exchange.Core.ItemTransaction.Validator
{
    public class GetItemTransactionQueryValidator:AbstractExchangeValidator<GetItemTransactionQuery>
    {
        public GetItemTransactionQueryValidator()
        {
            RuleFor(query => query.ItemTransactionId).NotNull().GreaterThan(0);
        }
    }
}