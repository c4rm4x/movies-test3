using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Persistence.Repositories
{
    public class MovieRepository :IMovieRepository
    {
        private readonly MoviesDbContext _context;

        public MovieRepository(MoviesDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Movie> GetByIDAsync(int movieID, CancellationToken cancellationToken = default)
        {
            return _context.Movies.FirstOrDefaultAsync(movie => movie.MovieID == movieID, cancellationToken);
        }

        public async Task<IEnumerable<Movie>> SearchAsync(string title, int? yearOfRelease, IEnumerable<string> genres, CancellationToken cancellationToken = default)
        {
            var filteredMovies = MoviesWithGenres;

            if (!string.IsNullOrEmpty(title)) filteredMovies = filteredMovies.Where(movie => movie.Title.Contains(title));
            if (yearOfRelease.HasValue) filteredMovies = filteredMovies.Where(movie => movie.YearOfRelease == yearOfRelease.Value);
            if (genres.Any()) filteredMovies = filteredMovies.Where(movie => movie.MovieGenres.Any(movieGenres => genres.Contains(movieGenres.Genre.Name)));

            return await filteredMovies.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Movie>> TopRankedAsync(int numberOfMovies, CancellationToken cancellationToken = default)
        {
            return await MoviesWithGenres
                .OrderByDescending(movie => movie.AverageRating)
                    .ThenBy(movie => movie.Title)
                .Take(numberOfMovies)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Movie>> TopRankedByUserAsync(int userID, int numberOfMovies, CancellationToken cancellationToken = default)
        {
            var filteredRatings = _context.Ratings.Where(rating => rating.UserID == userID).AsNoTracking();

            return await MoviesWithGenres
                .Join(filteredRatings, movie => movie.MovieID, rating => rating.MovieID, (movie, rating) => new { movie, rating })
                .OrderByDescending(_ => _.rating.Value)
                    .ThenBy(_ => _.movie.Title)
                .Take(numberOfMovies)
                .Select(_ => _.movie)
                .ToListAsync(cancellationToken);
        }

        private IQueryable<Movie> MoviesWithGenres => _context.Movies
            .Include(movie => movie.MovieGenres)
                .ThenInclude(movieGenres => movieGenres.Genre)
            .AsNoTracking();
    }
}
