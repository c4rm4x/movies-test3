using Movies.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> SearchAsync(string title, int? yearOfRelease, IEnumerable<string> genres, CancellationToken cancellationToken = default);

        Task<IEnumerable<Movie>> TopRankedAsync(int numberOfMovies, CancellationToken cancellationToken = default);

        Task<IEnumerable<Movie>> TopRankedByUserAsync(int userID, int numberOfMovies, CancellationToken cancellationToken = default);

        Task<Movie> GetByIDAsync(int movieID, CancellationToken cancellationToken = default);
    }
}
