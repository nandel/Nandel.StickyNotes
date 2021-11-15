using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nandel.Modules;
using Nandel.StikyNotes.Provider.EntityFramework;
using Nandel.StikyNotes.Provider.EntityFramework.Context;
using Nandel.StikyNotes.Providers.Cosmos.Context;

namespace Nandel.StikyNotes.Providers.Cosmos
{
    [DependsOn(
        typeof(EntityFrameworkModule)
        )]
    public class CosmosModule : IModule, IHasStart
    {
        private readonly IConfiguration _configuration;

        public CosmosModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SitkyNotesDbContext, CosmosStikyNotesDbContext>(options =>
            {
                var connectionString = _configuration.GetConnectionString("Cosmos") ?? _configuration.GetValue<string>("Cosmos:ConnectionString");
                var databaseName = _configuration.GetValue<string>("Cosmos:DatabaseName");
                
                options.UseCosmos(connectionString, databaseName);
            });
        }
        
        public async Task StartAsync(IServiceProvider services, CancellationToken cancellationToken)
        {
            using var scope = services.CreateScope();
            await using var db = scope.ServiceProvider.GetRequiredService<SitkyNotesDbContext>();
            await db.Database.EnsureCreatedAsync(cancellationToken);
        }

        public static bool HasValidConfiguration(IConfiguration configuration)
        {
            return 
                (configuration.GetSection("ConnectionStrings:Cosmos").Exists() || configuration.GetSection("Cosmos:ConnectionString").Exists())
                && configuration.GetSection("Cosmos:DatabaseName").Exists()
                ;
        }
    }
}