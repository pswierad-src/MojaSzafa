using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MojaSzafa.DB;

namespace MojaSzafa.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = CreateWebHostBuilder(args).Build();

            using (var s = hostBuilder.Services.CreateScope())
            {
                var services = s.ServiceProvider;
                try
                {
                    SeedData.Initialize(services);
                }
                catch
                {
                    new Exception("Error while seeding database");
                }
            }
            hostBuilder.Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
