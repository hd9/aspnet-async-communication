using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenPipes;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ResponseSvc.Core.Config;
using ResponseSvc.Core.Consumers;
using ResponseSvc.Core.Services;

namespace ResponseSvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        readonly AppConfig cfg;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            cfg = Configuration.Get<AppConfig>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddTransient<ICatalogSvc, CatalogSvc>();

            // allow auto-rebuilding the cshtml after changes (dev-only)
            // https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-compilation?view=aspnetcore-3.1&tabs=visual-studio
#if DEBUG
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
#endif

            services.AddMassTransit(x =>
            {
                x.AddConsumer<ProductInfoRequestConsumer>();

                x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(c =>
                {
                    c.Host(cfg.MassTransit.Host);
                    c.ReceiveEndpoint(cfg.MassTransit.Queue, e =>
                    {
                        e.PrefetchCount = 16;
                        e.UseMessageRetry(r => r.Interval(2, 3000));
                        e.ConfigureConsumer<ProductInfoRequestConsumer>(context);
                    });
                }));
            });

            services.AddMassTransitHostedService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
