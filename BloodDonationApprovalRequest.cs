using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class BloodDonationApprovalRequest
{
    public Guid Id { get; set; }

    public int UserId { get; set; }

    public string? ImageName { get; set; }

    public string? ImageUrl { get; set; }

    public string? BloodDonations { get; set; }

    public DateTime AddDate { get; set; }

    public string? AddUser { get; set; }

    public DateTime? EditDate { get; set; }

    public string? EditUser { get; set; }

    public byte StatusId { get; set; }

    public virtual ICollection<ApprovalConfirmationHistory> ApprovalConfirmationHistories { get; } = new List<ApprovalConfirmationHistory>();

    public virtual User User { get; set; } = null!;
}
