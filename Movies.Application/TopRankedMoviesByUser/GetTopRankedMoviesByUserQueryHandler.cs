using MediatR;
using Movies.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.TopRankedMoviesByUser
{
    public class GetTopRankedMoviesByUserQueryHandler : IRequestHandler<GetTopRankedMoviesByUserQuery, GetTopRankedMoviesByUserQueryResponse>
    {
        private readonly IMovieRepository _movies;

        public GetTopRankedMoviesByUserQueryHandler(IMovieRepository movies)
        {
            _movies = movies ?? throw new ArgumentNullException(nameof(movies));
        }

        public async Task<GetTopRankedMoviesByUserQueryResponse> Handle(GetTopRankedMoviesByUserQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movies.TopRankedByUserAsync(request.UserID, request.NumberOfMovies, cancellationToken);

            return new GetTopRankedMoviesByUserQueryResponse(movies);
        }
    }
}
