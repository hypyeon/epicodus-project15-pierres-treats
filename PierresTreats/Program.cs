using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PierresTreats.Models;
using Microsoft.AspNetCore.Identity;

namespace PierresTreats
{
  class Program
  {
    static void Main(string[] args)
    {
      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
      builder.Services.AddControllersWithViews();
      builder.Services
        .AddDbContext<PierresTreatsContext>(
          dbContextOptions => dbContextOptions
          .UseMySql(
            builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"])
          )
        );

      builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<PierresTreatsContext>()
        .AddDefaultTokenProviders();
      
      builder.Services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 0;
      });

      WebApplication app = builder.Build();

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}"
      );

      app.Run();
    }
  }
}