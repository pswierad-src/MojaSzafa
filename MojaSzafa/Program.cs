using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MojaSzafa.Data;

namespace MojaSzafa
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
