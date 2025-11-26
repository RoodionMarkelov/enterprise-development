using Microsoft.EntityFrameworkCore;
using Domain;
using Infrastructure.Db.Seeder;


namespace Infrastructure.Db;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{ 
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Visit> Visits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var seeder = new DbSeeder();

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