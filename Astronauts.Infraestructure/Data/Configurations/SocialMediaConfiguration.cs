using Astronauts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astronauts.Infraestructure.Data.Configurations
{
    public class SocialMediaConfiguration
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.ToTable("SocialMedia");

            builder.HasKey(e => e.Id );

            builder.Property(e => e.Id);

            builder.Property(e => e.Description)
            .HasMaxLength(20)
            .IsRequired()
            .IsUnicode(true)
            .HasColumnType("string");
        }
    }
}
