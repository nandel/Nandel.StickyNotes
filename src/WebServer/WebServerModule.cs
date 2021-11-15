using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nandel.Modules;
using Nandel.StikyNotes.Providers.Cosmos;
using Nandel.StikyNotes.Providers.Discord;
using Nandel.StikyNotes.Providers.Sqlite;
using Nandel.StikyNotes.Services;

namespace Nandel.StikyNotes
{
    [DependsOn(
        typeof(DiscordProviderModule)
        )]
    public class WebServerModule : IModule
    {
        private readonly IConfiguration _configuration;

        public WebServerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (CosmosModule.HasValidConfiguration(_configuration))
            {
                services.AddModule<CosmosModule>();
            }
            else if (SqliteModule.HasValidConfiguration(_configuration))
            {
                services.AddModule<SqliteModule>();
            }
            else
            {
                throw new InvalidOperationException("Não existe uma configuração válida para o banco de dados");
            }
            
            services.AddHostedService<DiscordBot>();
        }
    }
}