using System;
using System.Collections.Generic;

namespace Add50Registration;

public partial class User
{
    public int Id { get; set; }

    public int? UserInformationId { get; set; }

    public int? HospitalId { get; set; }

    public DateTime AddDate { get; set; }

    public string? AddUser { get; set; }

    public DateTime? EditDate { get; set; }

    public string? EditUser { get; set; }

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<ApprovalConfirmationHistory> ApprovalConfirmationHistories { get; } = new List<ApprovalConfirmationHistory>();

    public virtual ICollection<BloodDonationApprovalRequest> BloodDonationApprovalRequests { get; } = new List<BloodDonationApprovalRequest>();

    public virtual ICollection<EventRegistration> EventRegistrations { get; } = new List<EventRegistration>();

    public virtual Hospital? Hospital { get; set; }

    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();

    public virtual ICollection<RegistrationConfirmationHistory> RegistrationConfirmationHistories { get; } = new List<RegistrationConfirmationHistory>();

    public virtual ICollection<UserClaim> UserClaims { get; } = new List<UserClaim>();

    public virtual UserInformation? UserInformation { get; set; }

    public virtual ICollection<UserLogin> UserLogins { get; } = new List<UserLogin>();

    public virtual ICollection<UserToken> UserTokens { get; } = new List<UserToken>();

    public virtual ICollection<Role> Roles { get; } = new List<Role>();
}
