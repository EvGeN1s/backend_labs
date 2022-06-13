using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ScrumBoardContext>(options => options.UseMySql(configuration.GetConnectionString("Default"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("Default"))
            ));
        }
    }
}
