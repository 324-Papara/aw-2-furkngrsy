using FluentValidation;

namespace Para.Api
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Id)
                .NotEmpty().WithMessage("Book id is required.")
                .InclusiveBetween(1, 10000).WithMessage("Book id must be between 1 and 10000.");

            RuleFor(book => book.Name)
                .NotEmpty().WithMessage("Book name is required.")
                .Length(5, 50).WithMessage("Book name must be between 5 and 50 characters.");

            RuleFor(book => book.Author)
                .NotEmpty().WithMessage("Book author info is required.")
                .Length(5, 50).WithMessage("Book author info must be between 5 and 50 characters.");

            RuleFor(book => book.PageCount)
                .NotEmpty().WithMessage("Page count is required.")
                .InclusiveBetween(50, 400).WithMessage("Page count must be between 50 and 400.")
                .Must((book, pageCount) => ValidatePageCount(book.Year, pageCount))
                .WithMessage("Invalid page count for the given year");

            RuleFor(book => book.Year)
                .NotEmpty().WithMessage("Book year is required.")
                .InclusiveBetween(1900, 2024).WithMessage("Book year must be between 1900 and 2024.");
        }

        private bool ValidatePageCount(int year, int pageCount)
        {
            if (year >= 1900 && year <= 1950)
            {
                return pageCount <= 100;
            }

            if (year >= 1951 && year <= 1999)
            {
                return pageCount <= 200;
            }

            return true;
        }
    }
}
