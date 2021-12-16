using Microsoft.Extensions.DependencyInjection;
using ProvaPratica.Application.Interfaces;
using ProvaPratica.Application.Services;

namespace ProvaPratica.Application
{
    public static class Configure
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
