using FluentValidation;

namespace Movies.Application.TopRankedMoviesByUser
{
    public class GetTopRankedMoviesByUserQueryValidator : AbstractValidator<GetTopRankedMoviesByUserQuery>
    {
        public GetTopRankedMoviesByUserQueryValidator()
        {
            RuleFor(e => e.NumberOfMovies).NotEmpty().WithMessage("The number of movies to retrieve must be a positive number");

            RuleFor(e => e. UserID).NotEmpty().WithMessage("An user ID is required");
        }
    }
}
