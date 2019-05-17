using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcPieShop.Models;

[assembly: HostingStartup(typeof(MvcPieShop.Areas.Identity.IdentityHostingStartup))]
namespace MvcPieShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                // appdbcontext will be used to store identity information. / configured to use sqlserver.
                services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();


            });
        }
    }
}