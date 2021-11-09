using Microsoft.Extensions.DependencyInjection;
using Nandel.Modules;
using Nandel.StikyNotes.Core.Repositories;
using Nandel.StikyNotes.Provider.EntityFramework.Repositories;

namespace Nandel.StikyNotes.Provider.EntityFramework
{
    public class EntityFrameworkModule : IModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMediaRepository, MediaRepository>();
        }
    }
}