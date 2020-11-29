using MediatR;
using Movies.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.SearchMovies
{
    public class SearchMoviesQueryHandler : IRequestHandler<SearchMoviesQuery, SearchMoviesQueryResponse>
    {
        private readonly IMovieRepository _movies;

        public SearchMoviesQueryHandler(IMovieRepository movies)
        {
            _movies = movies ?? throw new ArgumentNullException(nameof(movies));
        }

        public async Task<SearchMoviesQueryResponse> Handle(SearchMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movies.SearchAsync(request.Filter.Title, request.Filter.YearOfRelease, request.Filter.Genres, cancellationToken);

            return new SearchMoviesQueryResponse(movies);
        }
    }
}
