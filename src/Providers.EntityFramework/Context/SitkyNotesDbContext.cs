using System;
using Core.Entities;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Provider.EntityFramework
{
    public class SitkyNotesDbContext : DbContext
    {
        private readonly IUserContext _userContext;
        private readonly ILogger<SitkyNotesDbContext> _logger;

        protected SitkyNotesDbContext(DbContextOptions options, IUserContext userContext, ILogger<SitkyNotesDbContext> logger) : base(options)
        {
            _userContext = userContext;
            _logger = logger;

            InstallEventHandlers();
        }

        private void InstallEventHandlers()
        {
            ChangeTracker.Tracked += (_, e) =>
            {
                if (e.Entry.State == EntityState.Added && e.Entry.Entity is IMustHaveTenant entity)
                {
                    entity.TenantId = _userContext.TenantId;
                }
            };
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SitkyNotesDbContext).Assembly);

            modelBuilder.Entity<Media>()
                .HasQueryFilter(x => x.TenantId == _userContext.TenantId);
        }
    }
}