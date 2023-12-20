using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Astronauts.Core.Entities;

public partial class AstronautMediaContext : DbContext
{
    public AstronautMediaContext(){}

    public AstronautMediaContext(DbContextOptions<AstronautMediaContext> options) : base(options){}

    public virtual DbSet<Astronaut> Astronauts { get; set; }
    public virtual DbSet<Mission> Missions { get; set; }
    public virtual DbSet<SocialMedia> SocialMedia { get; set; }
    public virtual DbSet<AstronautMission> AstronautMissions { get; set; }
    public virtual DbSet<Security> Securities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Astronaut>()
                .HasMany(a => a.Missions)
                .WithMany(m => m.Astronauts)
                .UsingEntity<AstronautMission>(
                    am => am.HasOne(prop => prop.Mission)
                    .WithMany()
                    .HasForeignKey(prop => prop.MissionId),

                    am => am.HasOne(prop => prop.Astronaut)
                    .WithMany()
                    .HasForeignKey(prop => prop.AstronautId),

                    am =>
                    {
                        am.HasKey(prop => new { prop.AstronautId, prop.MissionId });
                    }
                );

        

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
