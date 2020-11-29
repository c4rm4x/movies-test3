using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Movies
{
    public static class ServiceRegistrationExtensions
    {
        private static Assembly ThisAssembly => typeof(ServiceRegistrationExtensions).Assembly;

        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddAutoMapper(ThisAssembly);

            return services;
        }
    }
}
