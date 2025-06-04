using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Covauto.Infrastructure;
using Covauto.Infrastructure.Data; 


namespace Covauto.Infrastructure
{
    public class AutosContextFactory : IDesignTimeDbContextFactory<AutosContext>
    {
        public AutosContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AutosContext>();
            optionsBuilder.UseSqlite("Data Source=Covauto.db"); // of vervang door jouw echte connectie

            return new AutosContext(optionsBuilder.Options);
        }
    }
}
