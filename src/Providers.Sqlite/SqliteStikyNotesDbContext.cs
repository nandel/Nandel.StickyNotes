using Microsoft.EntityFrameworkCore;
using Provider.EntityFramework;

namespace Providers.EntityFramework.Sqlite
{
    public class SqliteStikyNotesDbContext : SitkyNotesDbContext
    {
        public SqliteStikyNotesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqliteStikyNotesDbContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}