using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nandel.Modules;
using Provider.EntityFramework;

namespace Providers.EntityFramework.Sqlite
{
    [DependsOn(
        typeof(EntityFrameworkModule)
        )]
    public class SqliteModule : IModule, IHasStart
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SitkyNotesDbContext, SqliteStikyNotesDbContext>(options =>
            {
                options.UseSqlite("Data Source=stikynotes.db");
            });
        }

        public async Task StartAsync(IServiceProvider services, CancellationToken cancellationToken)
        {
            using var scope = services.CreateScope();
            await scope.ServiceProvider.GetRequiredService<SitkyNotesDbContext>()
                .Database
                .MigrateAsync(cancellationToken: cancellationToken);
        }
    }
}