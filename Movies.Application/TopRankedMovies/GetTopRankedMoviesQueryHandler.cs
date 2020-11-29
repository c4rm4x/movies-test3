using MediatR;
using Movies.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.TopRankedMovies
{
    public class GetTopRankedMoviesQueryHandler : IRequestHandler<GetTopRankedMoviesQuery, GetTopRankedMoviesQueryResponse>
    {
        private readonly IMovieRepository _movies;

        public GetTopRankedMoviesQueryHandler(IMovieRepository movies)
        {
            _movies = movies ?? throw new ArgumentNullException(nameof(movies));
        }

        public async Task<GetTopRankedMoviesQueryResponse> Handle(GetTopRankedMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movies.TopRankedAsync(request.NumberOfMovies, cancellationToken);

            return new GetTopRankedMoviesQueryResponse(movies);
        }
    }
}
