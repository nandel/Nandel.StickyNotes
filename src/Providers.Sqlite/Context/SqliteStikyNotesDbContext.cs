using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Provider.EntityFramework;

namespace Providers.EntityFramework.Sqlite
{
    public class SqliteStikyNotesDbContext : SitkyNotesDbContext
    {
        public SqliteStikyNotesDbContext(DbContextOptions options, IUserContext userContext, ILogger<SitkyNotesDbContext> logger) : base(options, userContext, logger)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqliteStikyNotesDbContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}