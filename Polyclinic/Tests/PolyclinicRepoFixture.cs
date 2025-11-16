using Application.Service;
using Infrastructure.InMemory.Seeders;
using Infrastructure.InMemory.Repositories;


namespace Tests;

public class PolyclinicRepoFixture
{
    public PatientService PatientService { get; }
    public DoctorService DoctorService { get; }
    public VisitService VisitService { get; }

    public PolyclinicRepoFixture()
    {
        var patientSeeder = new InMemoryPatientRepositorySeeder();
        var doctorSeeder = new InMemoryDoctorRepositorySeeder();
        var visitSeeder = new InMemoryVisitRepositorySeeder(patientSeeder, doctorSeeder);

        var patientRepository = new InMemoryPatientRepository(patientSeeder);
        var doctorRepository = new InMemoryDoctorRepository(doctorSeeder);
        var visitRepository = new InMemoryVisitRepository(visitSeeder);

        PatientService = new PatientService(patientRepository);
        DoctorService = new DoctorService(doctorRepository);
        VisitService = new VisitService(visitRepository, patientRepository, doctorRepository);
    }
}
