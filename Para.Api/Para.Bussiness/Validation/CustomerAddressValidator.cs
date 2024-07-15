using FluentValidation;
using Para.Schema.Models;

namespace Para.Bussiness.Validation
{
    public class CustomerAddressValidator : AbstractValidator<CustomerAddress>
    {
        public CustomerAddressValidator()
        {
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.AddressLine).NotEmpty().WithMessage("Address Line is required.");
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("Zip Code is required.");
        }
    }
}
