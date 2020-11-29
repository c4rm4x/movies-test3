using MediatR;

namespace Movies.Application.CreateRating
{
    public class CreateRatingCommand : IRequest<CreateRatingCommandResponse>
    {
        public int UserID { get; private set; }

        public int MovieID { get; private set; }

        public int Rating { get; private set; }

        private CreateRatingCommand()
        {

        }

        public CreateRatingCommand(int movieID, int userID, int rating)
        {
            UserID = userID;
            MovieID = movieID;
            Rating = rating;
        }
    }
}
