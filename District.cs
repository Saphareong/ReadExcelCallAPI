using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class District
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int ProvinceId { get; set; }

    public virtual Province Province { get; set; } = null!;

    public virtual ICollection<Ward> Wards { get; } = new List<Ward>();
}
