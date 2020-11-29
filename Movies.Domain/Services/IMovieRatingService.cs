using Movies.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Domain.Services
{
    public interface IMovieRatingService
    {
        Task AddOrUpdateAsync(Movie movie, User user, int rating, CancellationToken cancellationToken = default);
    }
}
