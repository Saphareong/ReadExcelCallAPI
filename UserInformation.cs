using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class UserInformation
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Address { get; set; }

    public string? CitizenId { get; set; }

    public string? NationalId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public byte? BloodTypeId { get; set; }

    public bool IsRhNegative { get; set; }

    public float? Height { get; set; }

    public float? Weight { get; set; }

    public string? AvatarUrl { get; set; }

    public decimal BloodPoint { get; set; }

    public DateTime AddDate { get; set; }

    public string? AddUser { get; set; }

    public DateTime? EditDate { get; set; }

    public string? EditUser { get; set; }

    public virtual ICollection<BloodDonation> BloodDonations { get; } = new List<BloodDonation>();

    public virtual BloodType? BloodType { get; set; }

    public virtual User User { get; set; } = null!;
}
