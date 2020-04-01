using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace INSTTemp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                   //.ConfigureKestrel((context, options) =>
                   //{
                   //    // Handle requests up to 50 MB
                   //    options.Limits.MaxRequestBodySize = 52428800;
                   //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
