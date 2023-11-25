using Astronauts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astronauts.Infraestructure.Data.Configurations;

public class AstronautSocialMediaConfiguration : IEntityTypeConfiguration<AstronautSocialMedia>
{
    public void Configure(EntityTypeBuilder<AstronautSocialMedia> builder)
    {
        builder.ToTable("AstronautSocialMedia");

        //builder.HasKey(e => new { e.AstronautId, e.SocialMediaId }) ;

        builder.Property(e => e.AstronautId);
        builder.Property(e => e.SocialMediaId);

        builder.Property(e => e.AstronautId)
        .IsRequired()
        .IsUnicode(false)
        .HasColumnType("int");

        builder.Property(e => e.SocialMediaId)
        .IsRequired()
        .IsUnicode(false)
        .HasColumnType("int");

        builder.Property(e => e.Link)
        .HasMaxLength(100)
       .IsUnicode(true)
       .HasColumnType("string");

    }
}
