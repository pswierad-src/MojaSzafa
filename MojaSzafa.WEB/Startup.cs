using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MojaSzafa.DB;
using MojaSzafa.INFRASTRUCTURE.IoC;
using System;

namespace MojaSzafa.WEB
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public IContainer Container { get; set; }

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<MojaSzafaContext>(options =>
                options.UseSqlServer(
                    _config.GetConnectionString("DefaultConnection")));

            services.AddHttpClient();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<ContainerModule>();
            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Wardrobe}/{action=Index}/{id?}");
            });
        }
    }
}
