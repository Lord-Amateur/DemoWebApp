using System;
using DemoWebApp.Areas.Identity.Data;
using DemoWebApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DemoWebApp.Areas.Identity.IdentityHostingStartup))]
namespace DemoWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DemoWebAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DemoWebAppContextConnection")));

                services.AddDefaultIdentity<DemoWebAppUser>(

                    options => { 
                        options.SignIn.RequireConfirmedAccount = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredLength = 1;
                        options.Password.RequireDigit = false;

                    })
                    .AddEntityFrameworkStores<DemoWebAppContext>();
            });
        }
    }
}