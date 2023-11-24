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
    public virtual DbSet<AstronautMission> AstronautMissions { get; set; }
    public virtual DbSet<AstronautSocialMedia> AstronautSocialMedia { get; set; }
    public virtual DbSet<Security> Securities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
