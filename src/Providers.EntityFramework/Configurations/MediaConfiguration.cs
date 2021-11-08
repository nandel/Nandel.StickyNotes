using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Provider.EntityFramework.Configurations
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(x => x.Key);

            builder.HasDiscriminator()
                .HasValue<HttpGet>(HttpGet.MediaType)
                .HasValue<Text>(Text.MediaType)
                ;
        }
    }
}