

using ByBiz.DAL;
using Microsoft.EntityFrameworkCore;

namespace ByBiz
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt => {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("default"));
            });
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();

            app.MapControllerRoute(
                name:"default",
                pattern:"{controller=home}/{action=index}/{id?}"
                );
            app.Run();

        }

    }
}


