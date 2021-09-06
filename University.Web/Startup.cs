using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using University.Infrastructure.Data;
using University.Infrastructure.Interfaces;
using University.Infrastructure.Repository;
using University.Services;
using University.Services.Dto;
using University.Services.Interfaces;
using University.Services.MappersProfiles;
using University.Services.ServiceAssistants;
using University.Web.Models.MappersProfiles.CourseProfiles;

namespace University.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<UniversityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(CourseToDtoProfile), typeof(CourseIndexProfile));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IAssistant<CourseDto>, CourseAssistant>();
            services.AddTransient<IAssistant<GroupDto>, GroupAssistant>();
            services.AddTransient<IAssistant<StudentDto>, StudentAssistant>();

            services.AddTransient<IService<CourseDto>, CourseService>();
            services.AddTransient<IService<GroupDto>, GroupService>();
            services.AddTransient<IService<StudentDto>, StudentService>();
        }

        public void Configure(IApplicationBuilder app,
            ILogger<Startup> logger,
            UniversityContext context)
        {
            app.UseExceptionHandler("/Error");
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            app.MigrationIfNotExist(context, logger);
        }
    }
}