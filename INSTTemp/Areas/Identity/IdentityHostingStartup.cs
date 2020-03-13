using INSTTemp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(INSTTemp.Areas.Identity.IdentityHostingStartup))]
namespace INSTTemp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) =>
            //{
            //    services.AddDbContext<APPDBC>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("DBCS")));

            //    services.AddDefaultIdentity<INSTTempUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<APPDBC>();
            //});
        }
    }
}