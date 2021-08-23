using Exchange.Domain.User.Query;
using FluentValidation;

namespace Exchange.Core.User.Validator
{
    public class GetUsersWithPagingQueryValidator:AbstractValidator<GetUsersWithPagingQuery>
    {

        public GetUsersWithPagingQueryValidator()
        {
            RuleFor(query => query.PageNumber).GreaterThan(0);
            RuleFor(query => query.PageSize).GreaterThan(0);
        }
    }
}