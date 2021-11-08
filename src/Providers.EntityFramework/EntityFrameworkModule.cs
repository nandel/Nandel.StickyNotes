using Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Nandel.Modules;
using Provider.EntityFramework.Repositories;

namespace Provider.EntityFramework
{
    public class EntityFrameworkModule : IModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMediaRepository, MediaRepository>();
        }
    }
}