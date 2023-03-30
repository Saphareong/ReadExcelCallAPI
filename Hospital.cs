using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class Hospital
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string? AvatarUrl { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? OpeningTime { get; set; }

    public bool IsActive { get; set; }

    public string? HospitalConfig { get; set; }

    public DateTime AddDate { get; set; }

    public string? AddUser { get; set; }

    public DateTime? EditDate { get; set; }

    public string? EditUser { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
