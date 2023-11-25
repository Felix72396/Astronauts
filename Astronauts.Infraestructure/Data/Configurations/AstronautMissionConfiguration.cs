using Astronauts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Astronauts.Infraestructure.Data.Configurations;
public class AstronautMissionConfiguration : IEntityTypeConfiguration<AstronautMission>
{
    public void Configure(EntityTypeBuilder<AstronautMission> builder)
    {
        builder.ToTable("AstronautMission");

        //builder.HasKey(e => new { e.AstronautId, e.MissionId });

        builder.Property(e => e.AstronautId);
        builder.Property(e => e.MissionId);

        builder.Property(e => e.AstronautId)
        .IsRequired()
        .IsUnicode(false)
        .HasColumnType("int");

        builder.Property(e => e.MissionId)
        .IsRequired()
        .IsUnicode(false)
        .HasColumnType("int");
    }
}
