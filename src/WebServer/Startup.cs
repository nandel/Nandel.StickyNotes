using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nandel.Modules;
using Nandel.Modules.AspNetCore;

namespace Nandel.StikyNotes
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddModulesHostedService();
            services.AddModule<WebServerModule>(new[]
            {
                "depois-colocar-aqui-as-dependencias"
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}