using Microsoft.EntityFrameworkCore;

namespace Provider.EntityFramework
{
    public class SitkyNotesDbContext : DbContext
    {
        public SitkyNotesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SitkyNotesDbContext).Assembly);
        }
    }
}