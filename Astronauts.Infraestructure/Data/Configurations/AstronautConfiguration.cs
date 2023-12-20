using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Astronauts.Core.Entities;

namespace Astronauts.Infraestructure.Data.Configurations;
public class AstronautConfiguration : IEntityTypeConfiguration<Astronaut>
{
    public void Configure(EntityTypeBuilder<Astronaut> builder)
    {
        builder.ToTable("Astronaut");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id);

        builder.Property(e => e.FirstName)
       .HasMaxLength(25)
       .IsRequired()
       .IsUnicode(false)
       .HasColumnType("varchar(25)");

        builder.Property(e => e.LastName)
        .HasMaxLength(25)
        .IsRequired()
        .IsUnicode(false)
        .HasColumnType("varchar(25)");

        builder.Property(e => e.Nationality)
        .HasMaxLength(20)
        .IsRequired()
        .IsUnicode(false)
        .HasColumnType("varchar(20)");

        builder.Property(e => e.Description)
        .HasMaxLength(200)
        .IsUnicode(true)
        .HasColumnType("nvarchar(200)");

        builder.Property(e => e.BirthDate)
        .IsRequired()
        .HasColumnType("date"); // Or appropriate datetime type for your database

        builder.Property(e => e.Status)
        .IsRequired()
        .HasColumnType("bit"); // Or appropriate boolean type for your database

        builder.Property(e => e.Photo)
        .HasColumnType("varbinary(max)")
        .IsRequired(false)
        .HasDefaultValueSql(null)
        .HasConversion(
        v => v ?? Array.Empty<byte>(), // Convert null to an empty byte array
        v => v == null || v.Length == 0 ? null : v);
    }
}
