using Domain;

namespace Infrastructure.Db.Seeders;
public class DbVisitRepositorySeeder
{
    /// <summary>
    /// List of all appointments
    /// </summary>

    private readonly List<Patient> _patients;
    private readonly List<Doctor> _doctors;

    public DbVisitRepositorySeeder(
        DbPatientRepositorySeeder patientSeeder,
        DbDoctorRepositorySeeder doctorSeeder)
    {
        _patients = patientSeeder.Patients;
        _doctors = doctorSeeder.Doctors;
    }

    public List<object> Visits =>
        [
            new
            {
                Id = 1,
                PatientId = _patients[0].Id,
                DoctorId = _doctors[0].Id,
                DateOfVisit = new DateTime(2024, 1, 15, 10, 30, 0),
                NumberOfCabinet = "101-A",
                IsAgain = false
            },
            new
            {
                Id = 2,
                PatientId = _patients[1].Id,
                DoctorId = _doctors[1].Id,
                DateOfVisit = new DateTime(2024, 1, 17, 14, 15, 0),
                NumberOfCabinet = "205-B",
                IsAgain = true
            },
            new
            {
                Id = 3,
                PatientId = _patients[4].Id,
                DoctorId = _doctors[2].Id,
                DateOfVisit = new DateTime(2024, 1, 19, 9, 0, 0),
                NumberOfCabinet = "315-C",
                IsAgain = false
            },
            new
            {
                Id = 4,
                PatientId = _patients[5].Id,
                DoctorId = _doctors[3].Id,
                DateOfVisit = new DateTime(2024, 1, 22, 11, 45, 0),
                NumberOfCabinet = "112-D",
                IsAgain = false
            },
            new
            {
                Id = 5,
                PatientId = _patients[2].Id,
                DoctorId = _doctors[4].Id,
                DateOfVisit = new DateTime(2024, 1, 13, 16, 20, 0),
                NumberOfCabinet = "308-E",
                IsAgain = true
            },
            new
            {
                Id = 6,
                PatientId = _patients[3].Id,
                DoctorId = _doctors[0].Id,
                DateOfVisit = new DateTime(2024, 1, 21, 13, 0, 0),
                NumberOfCabinet = "101-A",
                IsAgain = false
            },
            new
            {
                Id = 7,
                PatientId = _patients[6].Id,
                DoctorId = _doctors[0].Id,
                DateOfVisit = new DateTime(2024, 1, 10, 9, 15, 0),
                NumberOfCabinet = "101-A",
                IsAgain = false
            },
            new
            {
                Id = 8,
                PatientId = _patients[6].Id,
                DoctorId = _doctors[1].Id,
                DateOfVisit = new DateTime(2024, 1, 12, 11, 30, 0),
                NumberOfCabinet = "205-B",
                IsAgain = true
            },
            new
            {
                Id = 9,
                PatientId = _patients[7].Id,
                DoctorId = _doctors[2].Id,
                DateOfVisit = new DateTime(2024, 1, 5, 15, 45, 0),
                NumberOfCabinet = "315-C",
                IsAgain = false
            },
            new
            {
                Id = 10,
                PatientId = _patients[7].Id,
                DoctorId = _doctors[4].Id,
                DateOfVisit = new DateTime(2024, 1, 8, 10, 0, 0),
                NumberOfCabinet = "308-E",
                IsAgain = true
            },
            new
            {
                Id = 11,
                PatientId = _patients[1].Id,
                DoctorId = _doctors[0].Id,
                DateOfVisit = new DateTime(2023, 12, 30, 14, 30, 0),
                NumberOfCabinet = "101-A",
                IsAgain = true
            },
            new
            {
                Id = 12,
                PatientId = _patients[1].Id,
                DoctorId = _doctors[3].Id,
                DateOfVisit = new DateTime(2024, 1, 18, 16, 0, 0),
                NumberOfCabinet = "112-D",
                IsAgain = false
            },
            new
            {
                Id = 13,
                PatientId = _patients[0].Id,
                DoctorId = _doctors[3].Id,
                DateOfVisit = new DateTime(2024, 1, 18, 16, 0, 0),
                NumberOfCabinet = "111-D",
                IsAgain = false
            },
            new
            {
                Id = 14,
                PatientId = _patients[2].Id,
                DoctorId = _doctors[6].Id,
                DateOfVisit = new DateTime(2024, 1, 18, 16, 0, 0),
                NumberOfCabinet = "121-C",
                IsAgain = false
            }
        ];

    public List<object> GetItems() => Visits;
    public int GetCurrentId() => 14;
}