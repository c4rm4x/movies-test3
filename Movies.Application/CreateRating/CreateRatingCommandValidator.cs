using FluentValidation;

namespace Movies.Application.CreateRating
{
    public class CreateRatingCommandValidator : AbstractValidator<CreateRatingCommand>
    {
        public CreateRatingCommandValidator()
        {
            RuleFor(e => e.MovieID).NotEmpty().WithMessage("A movie ID is required");

            RuleFor(e => e.UserID).NotEmpty().WithMessage("An user ID is required");

            RuleFor(e => e.Rating).InclusiveBetween(1, 5).WithMessage("The rating must be an integer between 1 and 5");
        }
    }
}
