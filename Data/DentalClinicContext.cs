using System;
using System.Collections.Generic;
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Data;

public partial class DentalClinicContext : DbContext
{
    public DentalClinicContext()
    {
    }

    public DentalClinicContext(DbContextOptions<DentalClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<ClinicCertification> ClinicCertifications { get; set; }

    public virtual DbSet<ClinicService> ClinicServices { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Dentist> Dentists { get; set; }

    public virtual DbSet<DentistWorkSlot> DentistWorkSlots { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=DentalClinic;User Id=sa;Password=2512004quocbao;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC27BA47FFF3");

            entity.ToTable("Appointment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppointmentResult).HasMaxLength(255);
            entity.Property(e => e.ClinicServiceId).HasColumnName("ClinicService_ID");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.DentistId).HasColumnName("Dentist_ID");
            entity.Property(e => e.IsRepeated).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.SlotId).HasColumnName("Slot_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.ClinicService).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ClinicServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_ClinicService");

            entity.HasOne(d => d.Customer).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Customer");

            entity.HasOne(d => d.Dentist).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DentistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Dentist");

            entity.HasOne(d => d.Slot).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Slot");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.HasKey(e => e.ClinicId).HasName("PK__Clinic__C2691A1694472A11");

            entity.ToTable("Clinic");

            entity.Property(e => e.ClinicId).HasColumnName("Clinic_ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ClinicOwnerId).HasColumnName("ClinicOwner_ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.ClinicOwner).WithMany(p => p.Clinics)
                .HasForeignKey(d => d.ClinicOwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clinic_User");
        });

        modelBuilder.Entity<ClinicCertification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClinicCe__3214EC271AF53A30");

            entity.ToTable("ClinicCertification");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CertificationImg)
                .HasMaxLength(255)
                .HasColumnName("Certification_Img");
            entity.Property(e => e.ClinicId).HasColumnName("Clinic_ID");

            entity.HasOne(d => d.Clinic).WithMany(p => p.ClinicCertifications)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClinicCertification_Clinic");
        });

        modelBuilder.Entity<ClinicService>(entity =>
        {
            entity.HasKey(e => e.ClinicServiceId).HasName("PK__ClinicSe__C2FAE8E4C6C577F1");

            entity.ToTable("ClinicService");

            entity.Property(e => e.ClinicServiceId).HasColumnName("ClinicService_ID");
            entity.Property(e => e.ClinicId).HasColumnName("Clinic_ID");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ServiceDescription).HasMaxLength(255);
            entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

            entity.HasOne(d => d.Clinic).WithMany(p => p.ClinicServices)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClinicService_Clinic");

            entity.HasOne(d => d.Service).WithMany(p => p.ClinicServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClinicService_Service");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__8CB286B990ABDAEB");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Sex).HasMaxLength(7);
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_User");
        });

        modelBuilder.Entity<Dentist>(entity =>
        {
            entity.HasKey(e => e.DentistId).HasName("PK__Dentist__4222AEABF006765C");

            entity.ToTable("Dentist");

            entity.Property(e => e.DentistId).HasColumnName("Dentist_ID");
            entity.Property(e => e.ClinicId).HasColumnName("Clinic_ID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ProfilePicture).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Clinic).WithMany(p => p.Dentists)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dentist_Clinic");

            entity.HasOne(d => d.User).WithMany(p => p.Dentists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dentist_User");
        });

        modelBuilder.Entity<DentistWorkSlot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DentistW__3214EC27F1F60530");

            entity.ToTable("DentistWorkSlot");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DentistId).HasColumnName("Dentist_ID");
            entity.Property(e => e.SlotId).HasColumnName("Slot_ID");

            entity.HasOne(d => d.Dentist).WithMany(p => p.DentistWorkSlots)
                .HasForeignKey(d => d.DentistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DentistWorkSlot_Dentist");

            entity.HasOne(d => d.Slot).WithMany(p => p.DentistWorkSlots)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DentistWorkSlot_Slot");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__DA6C7FE1806EF443");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Appointment).WithMany(p => p.Payments)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Appointment");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__BD1A239CA23E3C58");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId).HasColumnName("Service_ID");
            entity.Property(e => e.ServiceDescription).HasMaxLength(255);
            entity.Property(e => e.ServiceName).HasMaxLength(50);
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PK__Slot__1AE2AAAEDABE0654");

            entity.ToTable("Slot");

            entity.Property(e => e.SlotId).HasColumnName("Slot_ID");
            entity.Property(e => e.ClinicId).HasColumnName("Clinic_ID");
            entity.Property(e => e.DayInWeek).HasMaxLength(12);

            entity.HasOne(d => d.Clinic).WithMany(p => p.Slots)
                .HasForeignKey(d => d.ClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Slot_Clinic");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__206D91902CBC5ACC");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Role).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
