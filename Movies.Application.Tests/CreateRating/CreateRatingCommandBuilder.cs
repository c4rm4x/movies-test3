using Movies.Application.CreateRating;
using Movies.Application.Tests.Internal;

namespace Movies.Application.Tests.CreateRating
{
    public class CreateRatingCommandBuilder : Builder<CreateRatingCommand>
    {
        public CreateRatingCommandBuilder()
        {
            With(e => e.Rating, ObjectMother.Create<int>(Context.WithRange(1, 5)));
        }

        public CreateRatingCommandBuilder WithRating(int rating)
        {
            With(e => e.Rating, rating);

            return this;
        }

        public CreateRatingCommandBuilder WithUserID(int userID)
        {
            With(e => e.UserID, userID);

            return this;
        }

        public CreateRatingCommandBuilder WithMovieID(int movieID)
        {
            With(e => e.MovieID, movieID);

            return this;
        }
    }
}
