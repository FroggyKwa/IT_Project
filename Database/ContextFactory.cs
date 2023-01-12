using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Database
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            _ = optionsBuilder.UseNpgsql(
    $"Host=localhost;Port=5432;Database=backend;Username=postgres;Password=postgres");
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
