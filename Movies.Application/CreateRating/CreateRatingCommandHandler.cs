using MediatR;
using Movies.Domain.Repositories;
using Movies.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.CreateRating
{
    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, CreateRatingCommandResponse>
    {
        private readonly IMovieRepository _movies;
        private readonly IUserRepository _users;
        private readonly IMovieRatingService _movieRatingService;

        public CreateRatingCommandHandler(
            IMovieRepository movies,
            IUserRepository users,
            IMovieRatingService movieRatingService)
        {
            _movies = movies ?? throw new ArgumentNullException(nameof(movies));
            _users = users ?? throw new ArgumentNullException(nameof(users));
            _movieRatingService = movieRatingService ?? throw new ArgumentNullException(nameof(movieRatingService));
        }

        public async Task<CreateRatingCommandResponse> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movies.GetByIDAsync(request.MovieID, cancellationToken);

            if (movie == null) return new ResourceNotFoundResponse($"No movie with id {request.MovieID} has been found");

            var user = await _users.GetByIDAsync(request.UserID, cancellationToken);

            if (user == null) return new ResourceNotFoundResponse($"No user with id {request.UserID} has been found");

            await _movieRatingService.AddOrUpdateAsync(movie, user, request.Rating, cancellationToken);

            return new CreateRatingCommandResponse();
        }
    }
}
