using Domain.Core.Abstractions.Repositories;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DI
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection serviceCollection,
            string connectionString)
        {
            serviceCollection.AddDbContext<EfContext>(
                options => options.UseNpgsql(connectionString));

            return serviceCollection;
        }
    }
}