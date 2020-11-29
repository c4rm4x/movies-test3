using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Domain.Repositories;
using Movies.Domain.Services;
using Movies.Persistence.Repositories;
using Movies.Persistence.Services;

namespace Movies.Persistence
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IMovieRatingService, MovieRatingService>();

            services.AddDbContext<MoviesDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MoviesDbConnectionString"));
            });

            return services;
        }
    }
}
