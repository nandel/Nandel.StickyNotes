using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nandel.StikyNotes.Core.Services;
using Nandel.StikyNotes.Provider.EntityFramework.Context;

namespace Nandel.StikyNotes.Providers.Cosmos.Context
{
    public class CosmosStikyNotesDbContext : SitkyNotesDbContext
    {
        public CosmosStikyNotesDbContext(DbContextOptions options, IUserContext userContext, ILogger<SitkyNotesDbContext> logger) : base(options, userContext, logger)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CosmosStikyNotesDbContext).Assembly);
        }
    }
}