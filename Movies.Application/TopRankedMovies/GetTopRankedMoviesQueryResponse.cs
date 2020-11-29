using Movies.Domain.Entities;
using System.Collections.Generic;

namespace Movies.Application.TopRankedMovies
{
    public class GetTopRankedMoviesQueryResponse
    {
        public IEnumerable<Movie> Movies { get; private set; }

        public GetTopRankedMoviesQueryResponse(IEnumerable<Movie> movies)
        {
            Movies = movies;
        }
    }
}