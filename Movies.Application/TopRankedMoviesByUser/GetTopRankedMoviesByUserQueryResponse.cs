using Movies.Domain.Entities;
using System.Collections.Generic;

namespace Movies.Application.TopRankedMoviesByUser
{
    public class GetTopRankedMoviesByUserQueryResponse
    {
        public IEnumerable<Movie> Movies { get; private set; }

        public GetTopRankedMoviesByUserQueryResponse(IEnumerable<Movie> movies)
        {
            Movies = movies;
        }
    }
}