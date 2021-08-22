using System.Data;
using Exchange.Domain.ExchangeUser.Query;
using FluentValidation;

namespace Exchange.Core.ExchangeUser.Validator
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