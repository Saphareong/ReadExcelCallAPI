using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class Event
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? EventCode { get; set; }

    public int EventTypeId { get; set; }

    public string? Area { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public TimeSpan WorkingTimeStart { get; set; }

    public TimeSpan WorkingTimeEnd { get; set; }

    public int HospitalId { get; set; }

    public string? ContactInformation { get; set; }

    public string? BloodTypeNeed { get; set; }

    public int MinParticipant { get; set; }

    public int MaxParticipant { get; set; }

    public DateTime AddDate { get; set; }

    public string? AddUser { get; set; }

    public DateTime? EditDate { get; set; }

    public string? EditUser { get; set; }

    public bool IsCancelled { get; set; }

    public string? Images { get; set; }

    public virtual ICollection<EventLocation> EventLocations { get; } = new List<EventLocation>();

    public virtual ICollection<EventRegistration> EventRegistrations { get; } = new List<EventRegistration>();

    public virtual EventType EventType { get; set; } = null!;

    public virtual Hospital Hospital { get; set; } = null!;
}
