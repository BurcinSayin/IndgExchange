using FluentValidation;
using FluentValidation.Results;

namespace Exchange.Core.Shared
{
    public abstract class AbstractExchangeValidator<T>:AbstractValidator<T>
    {
        protected override bool PreValidate(ValidationContext<T> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure(typeof(T).Name,   "cannot be null"));
                return false;
            }
            
            return base.PreValidate(context, result);
        }
    }
}