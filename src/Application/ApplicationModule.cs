using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nandel.Modules;
using Nandel.StikyNotes.Core;

namespace Nandel.StikyNotes.Application
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