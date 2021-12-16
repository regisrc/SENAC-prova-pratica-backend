using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProvaPratica.Application;
using ProvaPratica.Infrastructure;
using ProvaPratica.Infrastructure.Context;

namespace ProvaPratica.API
{
    public class Startup
    {
        readonly string CorsPolicy = "_AllowAnyOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProvaPratica.API", Version = "v1" });
            });
            services.AddDbContext<ProvaPraticaContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("Default"));
            });

            services.AddApplication();
            services.AddInfrastructure();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProvaPratica.API v1"));
            }

            app.UseRouting();

            app.UseCors(CorsPolicy);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
