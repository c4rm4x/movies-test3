using FluentValidation;

namespace Movies.Application.TopRankedMovies
{
    public class GetTopRankedMoviesQueryValidator : AbstractValidator<GetTopRankedMoviesQuery>
    {
        public GetTopRankedMoviesQueryValidator()
        {
            RuleFor(e => e.NumberOfMovies).NotEmpty().WithMessage("The number of movies to retrieve must be a positive number");
        }
    }
}
