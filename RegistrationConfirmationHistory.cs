using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class RegistrationConfirmationHistory
{
    public Guid EventRegistrationId { get; set; }

    public int ConfirmUserId { get; set; }

    public DateTime AddDate { get; set; }

    public virtual User ConfirmUser { get; set; } = null!;

    public virtual EventRegistration EventRegistration { get; set; } = null!;
}
