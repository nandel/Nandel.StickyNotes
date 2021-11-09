using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nandel.StikyNotes.Core.Entities;

namespace Nandel.StikyNotes.Provider.EntityFramework.Configurations
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(x => new
            {
                x.TenantId,
                x.Key
            });

            builder.HasDiscriminator()
                .HasValue<HttpGet>(HttpGet.MediaType)
                .HasValue<Text>(Text.MediaType)
                ;
        }
    }
}