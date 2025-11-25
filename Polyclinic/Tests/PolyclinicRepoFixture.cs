using Application.Service;
using Infrastructure.InMemory.Repositories;
using Domain.Seeder;

namespace Tests;

public class PolyclinicRepoFixture
{
    public PatientService PatientService { get; }
    public DoctorService DoctorService { get; }
    public VisitService VisitService { get; }

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
