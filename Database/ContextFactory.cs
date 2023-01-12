using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables(".env");
            var configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            _ = optionsBuilder.UseNpgsql(configuration["DATABASE_URL"]);
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
