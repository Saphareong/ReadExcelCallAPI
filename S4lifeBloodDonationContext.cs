using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Add50Registration;

public partial class S4lifeBloodDonationContext : DbContext
{
    public S4lifeBloodDonationContext()
    {
    }

    public S4lifeBloodDonationContext(DbContextOptions<S4lifeBloodDonationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApprovalConfirmationHistory> ApprovalConfirmationHistories { get; set; }

    public virtual DbSet<BloodDonation> BloodDonations { get; set; }

    public virtual DbSet<BloodDonationApprovalRequest> BloodDonationApprovalRequests { get; set; }

    public virtual DbSet<BloodType> BloodTypes { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventLocation> EventLocations { get; set; }

    public virtual DbSet<EventRegistration> EventRegistrations { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationType> NotificationTypes { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<RegistrationConfirmationHistory> RegistrationConfirmationHistories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleClaim> RoleClaims { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserClaim> UserClaims { get; set; }

    public virtual DbSet<UserInformation> UserInformations { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserToken> UserTokens { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=blood-donation.cckewusmrnlq.ap-southeast-1.rds.amazonaws.com;Initial Catalog=S4Life_BloodDonation;Persist Security Info=True;User ID=Klee;Password=Mwauhahaha,-lucky-all-my-new-bombs-are-waterproof!;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApprovalConfirmationHistory>(entity =>
        {
            entity.HasKey(e => e.BloodDonationId);

            entity.HasIndex(e => e.ApprovalRequestId, "IX_ApprovalConfirmationHistories_ApprovalRequestId");

            entity.HasIndex(e => e.ConfirmUserId, "IX_ApprovalConfirmationHistories_ConfirmUserId");

            entity.Property(e => e.BloodDonationId).ValueGeneratedNever();

            entity.HasOne(d => d.ApprovalRequest).WithMany(p => p.ApprovalConfirmationHistories).HasForeignKey(d => d.ApprovalRequestId);

            entity.HasOne(d => d.BloodDonation).WithOne(p => p.ApprovalConfirmationHistory)
                .HasForeignKey<ApprovalConfirmationHistory>(d => d.BloodDonationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ConfirmUser).WithMany(p => p.ApprovalConfirmationHistories).HasForeignKey(d => d.ConfirmUserId);
        });

        modelBuilder.Entity<BloodDonation>(entity =>
        {
            entity.HasIndex(e => new { e.DonationDate, e.UserInformationId }, "IX_BloodDonations_DonationDate_UserInformationId").IsUnique();

            entity.HasIndex(e => e.EventRegistrationId, "IX_BloodDonations_EventRegistrationId")
                .IsUnique()
                .HasFilter("([EventRegistrationId] IS NOT NULL)");

            entity.HasIndex(e => e.UserInformationId, "IX_BloodDonations_UserInformationId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BloodBagCode)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.EventCode)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.HasOne(d => d.EventRegistration).WithOne(p => p.BloodDonation).HasForeignKey<BloodDonation>(d => d.EventRegistrationId);

            entity.HasOne(d => d.UserInformation).WithMany(p => p.BloodDonations).HasForeignKey(d => d.UserInformationId);
        });

        modelBuilder.Entity<BloodDonationApprovalRequest>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_BloodDonationApprovalRequests_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AddUser)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.BloodDonations).IsUnicode(false);
            entity.Property(e => e.EditUser)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.ImageName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.StatusId).HasDefaultValueSql("(CONVERT([tinyint],(1)))");

            entity.HasOne(d => d.User).WithMany(p => p.BloodDonationApprovalRequests).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BloodType>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasIndex(e => e.ProvinceId, "IX_Districts_ProvinceId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(32);

            entity.HasOne(d => d.Province).WithMany(p => p.Districts).HasForeignKey(d => d.ProvinceId);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasIndex(e => e.EventCode, "IX_Events_EventCode");

            entity.HasIndex(e => e.EventTypeId, "IX_Events_EventTypeId");

            entity.HasIndex(e => e.HospitalId, "IX_Events_HospitalId");

            entity.Property(e => e.AddUser)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.BloodTypeNeed).IsUnicode(false);
            entity.Property(e => e.ContactInformation)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(512);
            entity.Property(e => e.EditUser)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.EventCode)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Images).IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.EventType).WithMany(p => p.Events).HasForeignKey(d => d.EventTypeId);

            entity.HasOne(d => d.Hospital).WithMany(p => p.Events).HasForeignKey(d => d.HospitalId);
        });

        modelBuilder.Entity<EventLocation>(entity =>
        {
            entity.HasIndex(e => e.EventId, "IX_EventLocations_EventId");

            entity.HasIndex(e => e.LocationId, "IX_EventLocations_LocationId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Event).WithMany(p => p.EventLocations).HasForeignKey(d => d.EventId);

            entity.HasOne(d => d.Location).WithMany(p => p.EventLocations).HasForeignKey(d => d.LocationId);
        });

        modelBuilder.Entity<EventRegistration>(entity =>
        {
            entity.HasIndex(e => e.EventId, "IX_EventRegistrations_EventId");

            entity.HasIndex(e => e.UserId, "IX_EventRegistrations_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AddUser)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Address).HasMaxLength(128);
            entity.Property(e => e.ConfirmUser)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.DocumentUrl)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.EditUser)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.EventCode)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Latitude)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Longitude)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Event).WithMany(p => p.EventRegistrations).HasForeignKey(d => d.EventId);

            entity.HasOne(d => d.User).WithMany(p => p.EventRegistrations).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(32);
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.Property(e => e.AddUser).HasMaxLength(256);
            entity.Property(e => e.Address).HasMaxLength(128);
            entity.Property(e => e.AvatarUrl).HasMaxLength(256);
            entity.Property(e => e.EditUser).HasMaxLength(256);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.HospitalConfig).IsUnicode(false);
            entity.Property(e => e.Latitude)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Longitude)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(128);
            entity.Property(e => e.OpeningTime).IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(128);
            entity.Property(e => e.Latitude)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Longitude)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(128);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasIndex(e => e.NotificationTypeId, "IX_Notifications_NotificationTypeId");

            entity.HasIndex(e => e.UserId, "IX_Notifications_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Content).HasMaxLength(256);
            entity.Property(e => e.Title).HasMaxLength(128);

            entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications).HasForeignKey(d => d.NotificationTypeId);

            entity.HasOne(d => d.User).WithMany(p => p.Notifications).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<NotificationType>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(32);
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(32);
        });

        modelBuilder.Entity<RegistrationConfirmationHistory>(entity =>
        {
            entity.HasKey(e => e.EventRegistrationId);

            entity.HasIndex(e => e.ConfirmUserId, "IX_RegistrationConfirmationHistories_ConfirmUserId");

            entity.Property(e => e.EventRegistrationId).ValueGeneratedNever();

            entity.HasOne(d => d.ConfirmUser).WithMany(p => p.RegistrationConfirmationHistories).HasForeignKey(d => d.ConfirmUserId);

            entity.HasOne(d => d.EventRegistration).WithOne(p => p.RegistrationConfirmationHistory)
                .HasForeignKey<RegistrationConfirmationHistory>(d => d.EventRegistrationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<RoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_RoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.HospitalId, "IX_Users_HospitalId");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.AddUser).HasMaxLength(256);
            entity.Property(e => e.EditUser).HasMaxLength(256);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.Hospital).WithMany(p => p.Users).HasForeignKey(d => d.HospitalId);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("UserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_UserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<UserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_UserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.UserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserInformation>(entity =>
        {
            entity.HasIndex(e => e.BloodTypeId, "IX_UserInformations_BloodTypeId");

            entity.HasIndex(e => e.CitizenId, "IX_UserInformations_CitizenId")
                .IsUnique()
                .HasFilter("([CitizenId] IS NOT NULL)");

            entity.HasIndex(e => e.NationalId, "IX_UserInformations_NationalId")
                .IsUnique()
                .HasFilter("([NationalId] IS NOT NULL)");

            entity.HasIndex(e => e.UserId, "IX_UserInformations_UserId").IsUnique();

            entity.Property(e => e.AddUser)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Address).HasMaxLength(128);
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.BloodPoint).HasColumnType("money");
            entity.Property(e => e.CitizenId)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.EditUser)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(64);
            entity.Property(e => e.Gender).HasMaxLength(6);
            entity.Property(e => e.NationalId)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.HasOne(d => d.BloodType).WithMany(p => p.UserInformations).HasForeignKey(d => d.BloodTypeId);

            entity.HasOne(d => d.User).WithOne(p => p.UserInformation).HasForeignKey<UserInformation>(d => d.UserId);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_UserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.UserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.UserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasIndex(e => e.DistrictId, "IX_Wards_DistrictId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(32);

            entity.HasOne(d => d.District).WithMany(p => p.Wards).HasForeignKey(d => d.DistrictId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
