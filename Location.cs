using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class Location
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public int WardId { get; set; }

    public int DistrictId { get; set; }

    public int ProvinceId { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public virtual ICollection<EventLocation> EventLocations { get; } = new List<EventLocation>();
}
