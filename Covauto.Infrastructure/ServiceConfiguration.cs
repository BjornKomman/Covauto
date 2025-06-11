using Covauto.Application.Repositories;
using Covauto.Infrastructure.Data;
using Covauto.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Covauto.Application.Repositories;
using Covauto.Infrastructure.Repositories;


namespace Covauto.Infrastructure
{
    public static class ServicesConfiguration
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            // Voeg de DbContext toe met SQLite
            services.AddDbContext<AutosContext>(options =>
                options.UseSqlite(connectionString));

            // Registreer repositories voor dependency injection
            services.AddScoped<AutoRepository, AutoRepository>();
            services.AddScoped<GebruikersRepository, GebruikersRepository>();
            services.AddScoped<RittenRepository, RittenRepository>();
        }
    }
}
