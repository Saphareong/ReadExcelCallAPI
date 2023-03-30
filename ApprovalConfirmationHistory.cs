using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class ApprovalConfirmationHistory
{
    public Guid BloodDonationId { get; set; }

    public int ConfirmUserId { get; set; }

    public Guid? ApprovalRequestId { get; set; }

    public DateTime AddDate { get; set; }

    public virtual BloodDonationApprovalRequest? ApprovalRequest { get; set; }

    public virtual BloodDonation BloodDonation { get; set; } = null!;

    public virtual User ConfirmUser { get; set; } = null!;
}
