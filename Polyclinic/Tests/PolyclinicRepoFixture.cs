using Application.Service;
using Infrastructure.InMemory.Repositories;
using Domain.Seeder;
namespace Tests;

/// <summary>
/// Test fixture for polyclinic repository that provides in-memory implementations
/// of services for testing purposes
/// </summary>
public class PolyclinicRepoFixture
{
    /// <summary>
    /// Patient service instance with in-memory repository
    /// </summary>
    public PatientService PatientService { get; }

    /// <summary>
    /// Doctor service instance with in-memory repository  
    /// </summary>
    public DoctorService DoctorService { get; }

    /// <summary>
    /// Visit service instance with in-memory repository
    /// </summary>
    public VisitService VisitService { get; }

    /// <summary>
    /// Initializes a new instance of the polyclinic repository fixture
    /// with seeded test data and in-memory repositories
    /// </summary>
    public PolyclinicRepoFixture()
    {
        var seeder = new DataSeeder();

        var patientRepository = new InMemoryPatientRepository(seeder);
        var doctorRepository = new InMemoryDoctorRepository(seeder);
        var visitRepository = new InMemoryVisitRepository(seeder);

        PatientService = new PatientService(patientRepository);
        DoctorService = new DoctorService(doctorRepository);
        VisitService = new VisitService(visitRepository, patientRepository, doctorRepository);
    }
}

