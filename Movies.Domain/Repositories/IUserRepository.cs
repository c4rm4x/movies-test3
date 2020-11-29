using Movies.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIDAsync(int userID, CancellationToken cancellationToken = default);
    }
}
