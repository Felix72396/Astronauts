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
            .HasColumnType("string");

            builder.Property(e => e.LastName)
            .HasMaxLength(25)
            .IsRequired()
            .IsUnicode(false)
            .HasColumnType("string");

            builder.Property(e => e.Nationality)
            .HasMaxLength(20)
            .IsRequired()
            .IsUnicode(false)
            .HasColumnType("string");


            builder.Property(e => e.Description)
            .HasMaxLength(200)
            .IsUnicode(true)
            .HasColumnType("string");

            builder.Property(e => e.BirthDate)
            .IsRequired()
            .HasColumnType("datetime");

            builder.Property(e => e.Status)
            .IsRequired()
            .HasColumnType("bool");

            builder.Property(e => e.Photo)
            .HasColumnType("byte[]");  
    }
}
