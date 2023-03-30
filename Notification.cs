using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class Notification
{
    public Guid Id { get; set; }

    public int UserId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime Date { get; set; }

    public int NotificationTypeId { get; set; }

    public int? EventId { get; set; }

    public bool IsRead { get; set; }

    public virtual NotificationType NotificationType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
