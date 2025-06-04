using Covauto.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

namespace Covauto.Infrastructure
{
    public static class ServicesConfiguration
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AutosContext>(options =>
                options.UseSqlite(connectionString));
        }
    }
}
