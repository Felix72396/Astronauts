using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Astronauts.Core.Entities;
using Astronauts.Core.Enumerations;

namespace Astronauts.Infraestructure.Data.Configurations;

public class SecurityConfiguration : IEntityTypeConfiguration<Security>
{
    public void Configure(EntityTypeBuilder<Security> builder)
    {

        builder.ToTable("Security");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id);

        builder.Property(e => e.User)
        .IsRequired()
        .HasMaxLength(30)
        .IsUnicode(false);

        builder.Property(e => e.UserName)
        .IsRequired()
        .HasMaxLength(30)
        .IsUnicode(false);

        builder.Property(e => e.Password)
       .IsRequired()
       .HasMaxLength(200)
       .IsUnicode(true);

        builder.Property(e => e.Role)
       .IsRequired()
       .HasMaxLength(15)
       .HasConversion(
        x => x.ToString(),
        x => (RoleType)Enum.Parse(typeof(RoleType), x));
    }
}
