using Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nandel.Modules;

namespace Application
{
    [DependsOn(
        typeof(CoreModule)
        )]
    public class ApplicationModule : IModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationModule).Assembly);
        }
    }
}