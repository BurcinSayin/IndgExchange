using Exchange.Domain.Item.Query;
using FluentValidation;

namespace Exchange.Core.Item.Validator
{
    public class GetItemQueryValidator:AbstractValidator<GetItemQuery>
    {
        public GetItemQueryValidator()
        {
            RuleFor(query => query.ItemId).GreaterThan(0);
        }
    }
}