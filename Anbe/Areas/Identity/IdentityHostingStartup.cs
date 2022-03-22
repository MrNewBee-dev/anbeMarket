using Anbe.Areas.Identity.Data;
using Anbe.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Anbe.Areas.Identity.IdentityHostingStartup))]
namespace Anbe.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AnbeContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AnbeContextConnection")));


                services.AddIdentity<ApplicationUser, ApplicationRole>()
               .AddDefaultUI()
               .AddEntityFrameworkStores<AnbeContext>()


               .AddRoles<ApplicationRole>()
               .AddDefaultTokenProviders();
                services.Configure<IdentityOptions>(options =>
                {
                    // Default Password settings.
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 1;
                    options.Password.RequiredUniqueChars = 0;
                });
            });
        }
    }
}