using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class Province
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<District> Districts { get; } = new List<District>();
}
