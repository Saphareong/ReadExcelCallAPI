using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class EventType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
