using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class EventRegistration
{
    public Guid Id { get; set; }

    public int UserId { get; set; }

    public byte? BloodTypeId { get; set; }

    public bool IsRhNegative { get; set; }

    public int EventId { get; set; }

    public string? EventCode { get; set; }

    public DateTime ParticipationDate { get; set; }

    public string? Address { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string? RegistrationForm { get; set; }

    public string? ConfirmationForm { get; set; }

    public int? DonationVolume { get; set; }

    public byte StatusId { get; set; }

    public string? DocumentUrl { get; set; }

    public DateTime AddDate { get; set; }

    public string? AddUser { get; set; }

    public DateTime? EditDate { get; set; }

    public string? EditUser { get; set; }

    public string? ConfirmUser { get; set; }

    public virtual BloodDonation? BloodDonation { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual RegistrationConfirmationHistory? RegistrationConfirmationHistory { get; set; }

    public virtual User User { get; set; } = null!;
}
