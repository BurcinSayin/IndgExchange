using Exchange.Domain.ExchangeUser.Query;
using FluentValidation;

namespace Exchange.Core.ExchangeUser.Validator
{
    public class GetUserQueryValidator:AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(query => query.ExchangeUserId).GreaterThan(0);
        }
    }
}