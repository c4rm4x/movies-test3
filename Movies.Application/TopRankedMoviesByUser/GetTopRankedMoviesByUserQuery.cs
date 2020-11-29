using MediatR;

namespace Movies.Application.TopRankedMoviesByUser
{
    public class GetTopRankedMoviesByUserQuery : IRequest<GetTopRankedMoviesByUserQueryResponse>
    {
        public int NumberOfMovies { get; private set; }

        public int UserID { get; private set; }

        private GetTopRankedMoviesByUserQuery()
        {

        }

        public GetTopRankedMoviesByUserQuery(int numberOfMovies, int userID)
        {
            NumberOfMovies = numberOfMovies;
            UserID = userID;
        }
    }
}
