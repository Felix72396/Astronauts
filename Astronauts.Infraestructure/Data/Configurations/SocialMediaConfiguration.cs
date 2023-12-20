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

            builder.Property(e => e.AstronautId)
            .HasColumnName("AstronautId")
            .HasColumnType("int")
            .IsRequired();

            builder.Property(e => e.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar(40)")
            .IsUnicode(true)
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(e => e.Link)
            .HasColumnName("Link")
            .HasColumnType("nvarchar(100)")
            .IsUnicode(false)
            .HasMaxLength(100)
            .IsRequired();

            builder.HasIndex(e => new { e.Description, e.AstronautId }).IsUnique();

            builder.HasOne(e => e.Astronaut)
           .WithMany(a => a.SocialMedia)
           .HasForeignKey(e => e.AstronautId)
           .IsRequired();
        }
    }
}
