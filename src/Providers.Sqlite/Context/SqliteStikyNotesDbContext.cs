using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nandel.StikyNotes.Core.Services;
using Nandel.StikyNotes.Provider.EntityFramework.Context;

namespace Nandel.StikyNotes.Providers.Sqlite.Context
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