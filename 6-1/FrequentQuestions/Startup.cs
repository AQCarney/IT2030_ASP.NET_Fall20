using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FrequentQuestions.Models;

namespace FrequentQuestions
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });

            services.AddControllersWithViews();

            services.AddDbContext<QuestionContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("QuestionContext")));
        }

        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "both",
                    pattern: "{controller=Home}/{action=Index}/topic/{topic}/category/{category}");

                endpoints.MapControllerRoute(
                    name: "topic",
                    pattern: "{controller=Home}/{action=Index}/topic/{topic}");

                endpoints.MapControllerRoute(
                 name: "category",
                 pattern: "{controller=Home}/{action=Index}/category/{category}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });
        }
    }
}
