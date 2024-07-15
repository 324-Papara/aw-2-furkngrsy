using FluentValidation;
using Para.Schema.Models;

namespace Para.Bussiness.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required.");
            RuleFor(x => x.IdentityNumber).NotEmpty().WithMessage("Identity Number is required.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Valid email is required.");
            RuleFor(x => x.CustomerNumber).GreaterThan(0).WithMessage("Customer Number must be greater than 0.");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date of Birth is required.");
        }
    }
}
