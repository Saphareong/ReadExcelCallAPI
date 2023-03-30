using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class BloodDonation
{
    public Guid Id { get; set; }

    public int UserInformationId { get; set; }

    public DateTime DonationDate { get; set; }

    public int DonationVolume { get; set; }

    public string? EventCode { get; set; }

    public string? BloodBagCode { get; set; }

    public Guid? EventRegistrationId { get; set; }

    public virtual ApprovalConfirmationHistory? ApprovalConfirmationHistory { get; set; }

    public virtual EventRegistration? EventRegistration { get; set; }

    public virtual UserInformation UserInformation { get; set; } = null!;
}
