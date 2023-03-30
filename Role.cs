using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public virtual ICollection<RoleClaim> RoleClaims { get; } = new List<RoleClaim>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
