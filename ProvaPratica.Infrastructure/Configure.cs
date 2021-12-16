using Microsoft.Extensions.DependencyInjection;
using ProvaPratica.Infrastructure.Interfaces;
using ProvaPratica.Infrastructure.Repositories;

namespace ProvaPratica.Infrastructure
{
    public static class Configure
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddRepositories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}
