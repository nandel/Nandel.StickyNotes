using Application.Discord;
using Microsoft.Extensions.DependencyInjection;
using Nandel.Modules;
using Providers.EntityFramework.Sqlite;
using WebServer.Services;

namespace WebServer
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