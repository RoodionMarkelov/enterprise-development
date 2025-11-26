using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Seeder;


namespace Infrastructure.Db;

/// <summary>
/// Database context for the Polyclinic application that represents the session with the database
/// and provides access to patient, doctor, and visit entities
/// </summary>
/// <param name="options">The options to be used by the DbContext</param>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Gets or sets the patients database set
    /// </summary>
    public DbSet<Patient> Patients { get; set; }

    /// <summary>
    /// Gets or sets the doctors database set
    /// </summary>
    public DbSet<Doctor> Doctors { get; set; }

    /// <summary>
    /// Gets or sets the visits database set
    /// </summary>
    public DbSet<Visit> Visits { get; set; }

    /// <summary>
    /// Configures the model that was discovered by convention from the entity types
    /// exposed in DbSet properties on the derived context
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var seeder = new DataSeeder();

        modelBuilder.Entity<Patient>(builder =>
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Passport).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Address).HasMaxLength(200);

            builder.HasData(seeder.Patients);
        });

        modelBuilder.Entity<Doctor>(builder =>
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Passport).IsRequired().HasMaxLength(20);
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);

            builder.HasData(seeder.Doctors);
        });

        modelBuilder.Entity<Visit>(builder =>
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.NumberOfCabinet).IsRequired().HasMaxLength(10);
            builder.Property(v => v.DateOfVisit).IsRequired();

            builder.HasOne(v => v.Patient)
                   .WithMany()
                   .HasForeignKey(v => v.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.Doctor)
                   .WithMany()
                   .HasForeignKey(v => v.DoctorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(seeder.Visits.Select(v => new
            {
                v.Id,
                v.PatientId,
                v.DoctorId,
                v.DateOfVisit,
                v.NumberOfCabinet,
                v.IsAgain
            }));
        });
    }
}