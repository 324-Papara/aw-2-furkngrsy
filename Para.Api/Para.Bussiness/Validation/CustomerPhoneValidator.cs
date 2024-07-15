using FluentValidation;
using Para.Schema.Models;

namespace Para.Bussiness.Validation
{
    public class CustomerPhoneValidator : AbstractValidator<CustomerPhone>
    {
        public CustomerPhoneValidator()
        {
            RuleFor(x => x.CountyCode).NotEmpty().WithMessage("County Code is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required.");
        }
    }
}
