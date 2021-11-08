using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nandel.Modules;

namespace Application
{
    public class ApplicationModule : IModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationModule).Assembly);
        }
    }
}