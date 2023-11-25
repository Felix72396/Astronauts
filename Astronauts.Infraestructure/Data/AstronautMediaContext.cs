using Microsoft.EntityFrameworkCore;

using Astronauts.Infraestructure.Data.Configurations;
using System.Reflection;

namespace Astronauts.Core.Entities;

public partial class AstronautMediaContext : DbContext
{
    public AstronautMediaContext(){}

    public AstronautMediaContext(DbContextOptions<AstronautMediaContext> options) : base(options){}

    public virtual DbSet<Astronaut> Astronauts { get; set; }
    public virtual DbSet<Mission> Missions { get; set; }
    public virtual DbSet<SocialMedia> SocialMedia { get; set; }
    //public virtual DbSet<AstronautMission> AstronautMissions { get; set; }
    //public virtual DbSet<AstronautSocialMedia> AstronautSocialMedia { get; set; }
    public virtual DbSet<Security> Securities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Astronaut>()
                .HasMany(m => m.Missions)
                .WithMany(a => a.Astronauts)
                .UsingEntity<AstronautMission>(
                    ma => ma.HasOne(prop => prop.Mission)
                    .WithMany()
                    .HasForeignKey(prop => prop.MissionId),
                    ma => ma.HasOne(prop => prop.Astronaut)
                    .WithMany()
                    .HasForeignKey(prop => prop.AstronautId),
                    ma =>
                    {
                        ma.HasKey(prop => new { prop.AstronautId, prop.MissionId });
                    }
                );

        modelBuilder.Entity<Astronaut>()
               .HasMany(m => m.SocialMedia)
               .WithMany(a => a.Astronauts)
               .UsingEntity<AstronautSocialMedia>(
                   ma => ma.HasOne(prop => prop.SocialMedia)
                   .WithMany()
                   .HasForeignKey(prop => prop.SocialMediaId),
                   ma => ma.HasOne(prop => prop.Astronaut)
                   .WithMany()
                   .HasForeignKey(prop => prop.AstronautId),
                   ma =>
                   {
                       ma.HasKey(prop => new { prop.AstronautId, prop.SocialMediaId });
                   }
               );

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
