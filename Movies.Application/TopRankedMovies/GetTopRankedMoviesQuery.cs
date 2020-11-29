using MediatR;

namespace Movies.Application.TopRankedMovies
{
    public class GetTopRankedMoviesQuery : IRequest<GetTopRankedMoviesQueryResponse>
    {
        public int NumberOfMovies { get; private set; }

        private GetTopRankedMoviesQuery()
        {

        }

        public GetTopRankedMoviesQuery(int numberOfMovies)
        {
            NumberOfMovies = numberOfMovies;
        }
    }
}
