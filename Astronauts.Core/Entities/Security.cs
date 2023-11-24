using Astronauts.Core.Enumerations;

namespace Astronauts.Core.Entities;

public class Security : BaseEntity
{
    public string User { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public RoleType Role { get; set; }
}