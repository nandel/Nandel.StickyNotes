using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Providers.EntityFramework.Sqlite.Configurations
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.ToTable("Media");
        }
    }
}