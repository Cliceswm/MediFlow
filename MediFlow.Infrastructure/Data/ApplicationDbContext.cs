using MediFlow.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Physician> Physicians => Set<Physician>();
    public DbSet<WorkingHours> WorkingHours => Set<WorkingHours>();
    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);   // keep this: it creates the login tables

        builder.Entity<Patient>(e =>
        {
            e.Property(p => p.FullName).HasMaxLength(200).IsRequired();
            e.Property(p => p.Email).HasMaxLength(256);
            e.HasIndex(p => p.UserId).IsUnique().HasFilter("[UserId] IS NOT NULL");
        });

        builder.Entity<Physician>(e =>
        {
            e.Property(p => p.FullName).HasMaxLength(200).IsRequired();
            e.Property(p => p.Specialty).HasMaxLength(100);
            e.HasIndex(p => p.UserId).IsUnique().HasFilter("[UserId] IS NOT NULL");
        });

        builder.Entity<WorkingHours>()
            .HasOne<Physician>().WithMany().HasForeignKey(w => w.PhysicianId);

        builder.Entity<Appointment>(e =>
        {
            e.Property(a => a.Status).HasConversion<string>().HasMaxLength(20);
            e.HasOne(a => a.Patient).WithMany().HasForeignKey(a => a.PatientId)
             .OnDelete(DeleteBehavior.Restrict);
            e.HasOne(a => a.Physician).WithMany().HasForeignKey(a => a.PhysicianId)
             .OnDelete(DeleteBehavior.Restrict);

            // A physician can't have two active appointments at the same time.
            // The DATABASE enforces this, so two people booking at the same
            // second can't both succeed.
            e.HasIndex(a => new { a.PhysicianId, a.StartUtc })
             .IsUnique()
             .HasFilter("[Status] <> 'Cancelled'");
        });
    }
}