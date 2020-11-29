using Movies.Domain.Entities;
using System.Collections.Generic;

namespace Movies.Application.SearchMovies
{
    public class SearchMoviesQueryResponse
    {
        public IEnumerable<Movie> Movies { get; private set; }

        public SearchMoviesQueryResponse(IEnumerable<Movie> movies)
        {
            Movies = movies;
        }
    }
}
