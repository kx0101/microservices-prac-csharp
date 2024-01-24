using microservice_prac.Data;
using Microsoft.EntityFrameworkCore;

namespace microservice_prac
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
        }
    }
}
