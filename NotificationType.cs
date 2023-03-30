using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class NotificationType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();
}
