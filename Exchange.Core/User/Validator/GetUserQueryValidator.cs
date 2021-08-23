using Exchange.Domain.User.Query;
using FluentValidation;

namespace Exchange.Core.User.Validator
{
    public class GetUserQueryValidator:AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(query => query.UserId).GreaterThan(0);
        }
    }
}