using Astronauts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astronauts.Infraestructure.Data.Configurations
{
    public class MissionConfiguration
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            builder.ToTable("Mission");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id);

            builder.Property(e => e.Title)
            .HasMaxLength(60)
            .IsRequired()
            .IsUnicode(false)
            .HasColumnType("string");

            builder.Property(e => e.Description)
            .HasMaxLength(500)
            .IsRequired()
            .IsUnicode(true)
            .HasColumnType("string");

        }
    }
}
