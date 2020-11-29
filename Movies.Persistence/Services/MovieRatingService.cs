using Movies.Domain.Entities;
using Movies.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Persistence.Services
{
    public class MovieRatingService : IMovieRatingService
    {
        private readonly MoviesDbContext _entities;

        public MovieRatingService(MoviesDbContext entities)
        {
            _entities = entities ?? throw new ArgumentNullException(nameof(entities));
        }

        public Task AddOrUpdateAsync(Movie movie, User user, int rating, CancellationToken cancellationToken = default)
        {
            // TODO: Implement Stored procedure call to create or update new rating and update the average rating for the given movie

            return Task.CompletedTask;
        }
    }
}
