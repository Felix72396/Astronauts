﻿using Astronauts.Core.Enumerations;

namespace Astronauts.Core.DTOs;

public class SecurityDto
{
    public int Id { get; set; }
    public string User { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public RoleType? Role { get; set; }
}
