﻿using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class Ward
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int DistrictId { get; set; }

    public virtual District District { get; set; } = null!;
}
