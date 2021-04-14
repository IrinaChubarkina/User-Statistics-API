using Domain.Core.Abstractions.Services;
using Domain.Services.Calculation;
using Domain.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Services
{
    public static class DI
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<ICalculationService, CalculationService>()
                .AddScoped<IUserService, UserService>();

            return serviceCollection;
        }
    }
}