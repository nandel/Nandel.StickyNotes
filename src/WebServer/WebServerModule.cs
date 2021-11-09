using Microsoft.Extensions.DependencyInjection;
using Nandel.Modules;
using Nandel.StikyNotes.Providers.Discord;
using Nandel.StikyNotes.Providers.Sqlite;
using Nandel.StikyNotes.Services;

namespace Nandel.StikyNotes
{
    [DependsOn(
        typeof(DiscordProviderModule),
        typeof(SqliteModule)
        )]
    public class WebServerModule : IModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<DiscordBot>();
        }
    }
}