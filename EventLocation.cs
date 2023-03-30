using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class EventLocation
{
    public Guid Id { get; set; }

    public int EventId { get; set; }

    public Guid LocationId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
}
