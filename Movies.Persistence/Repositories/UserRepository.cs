using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MoviesDbContext _context;

        public UserRepository(MoviesDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<User> GetByIDAsync(int userID, CancellationToken cancellationToken = default)
        {
            return _context.Users.FirstOrDefaultAsync(user => user.UserID == userID, cancellationToken);
        }
    }
}
