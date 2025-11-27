using Domain.Seeder;
using Domain;

namespace Tests;

/// <summary>
/// Class with data for unit tests
/// </summary>
public class PolyclinicFixture
{
    /// <summary>
    /// Seeder with data for unit tests
    /// </summary>
    private readonly DataSeeder _seeder = new();

    /// <summary>
    /// List of all patients
    /// </summary>
    public List<Patient> Patients => _seeder.Patients;

    /// <summary>
    /// List of all doctors
    /// </summary>
    public List<Doctor> Doctors => _seeder.Doctors;

    /// <summary>
    /// List of all appointments
    /// </summary>
    public List<Visit> Visits => _seeder.Visits;
}