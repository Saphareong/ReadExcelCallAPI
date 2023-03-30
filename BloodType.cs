using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class BloodType
{
    public byte Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<UserInformation> UserInformations { get; } = new List<UserInformation>();
}
