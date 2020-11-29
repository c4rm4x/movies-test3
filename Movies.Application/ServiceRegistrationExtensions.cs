using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Movies.Application
{
    public static class ServiceRegistrationExtensions
    {
        private static Assembly ThisAssembly => typeof(ServiceRegistrationExtensions).Assembly;

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(ThisAssembly);

            AssemblyScanner
                .FindValidatorsInAssembly(ThisAssembly)
                .ForEach(validator => services.AddTransient(validator.InterfaceType, validator.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
