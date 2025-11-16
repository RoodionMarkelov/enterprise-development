using Domain;
using Infrastructure.InMemory.Seeders;
namespace Infrastructure.InMemory.Seeders;
public class InMemoryVisitRepositorySeeder
{
    /// <summary>
    /// List of all appointments
    /// </summary>

    private readonly List<Patient> _patients;
    private readonly List<Doctor> _doctors;

    public InMemoryVisitRepositorySeeder(
        InMemoryPatientRepositorySeeder patientSeeder,
        InMemoryDoctorRepositorySeeder doctorSeeder)
    {
        _patients = patientSeeder.Patients;
        _doctors = doctorSeeder.Doctors;
    }

    public List<Visit> Visits =>
    [
        new()
        {
            Id = 1,
            Patient = _patients[0],
            Doctor = _doctors[0],
            DateOfVisit = new DateTime(2024, 1, 15, 10, 30, 0),
            NumberOfCabinet = "101-A",
            IsAgain = false
        },
        new()
        {
            Id = 2,
            Patient = _patients[1],
            Doctor = _doctors[1],
            DateOfVisit = new DateTime(2024, 1, 17, 14, 15, 0),
            NumberOfCabinet = "205-B",
            IsAgain = true
        },
        new()
        {
            Id = 3,
            Patient = _patients[4],
            Doctor = _doctors[2],
            DateOfVisit = new DateTime(2024, 1, 19, 9, 0, 0),
            NumberOfCabinet = "315-C",
            IsAgain = false
        },
        new()
        {
            Id = 4,
            Patient = _patients[5],
            Doctor = _doctors[3],
            DateOfVisit = new DateTime(2024, 1, 22, 11, 45, 0),
            NumberOfCabinet = "112-D",
            IsAgain = false
        },
        new()
        {
            Id = 5,
            Patient = _patients[2],
            Doctor = _doctors[4],
            DateOfVisit = new DateTime(2024, 1, 13, 16, 20, 0),
            NumberOfCabinet = "308-E",
            IsAgain = true
        },
        new()
        {
            Id = 6,
            Patient = _patients[3],
            Doctor = _doctors[0],
            DateOfVisit = new DateTime(2024, 1, 21, 13, 0, 0),
            NumberOfCabinet = "101-A",
            IsAgain = false
        },
        new()
        {
            Id = 7,
            Patient = _patients[6],
            Doctor = _doctors[0],
            DateOfVisit = new DateTime(2024, 1, 10, 9, 15, 0),
            NumberOfCabinet = "101-A",
            IsAgain = false
        },
        new()
        {
            Id = 8,
            Patient = _patients[6],
            Doctor = _doctors[1],
            DateOfVisit = new DateTime(2024, 1, 12, 11, 30, 0),
            NumberOfCabinet = "205-B",
            IsAgain = true
        },
        new()
        {
            Id = 9,
            Patient = _patients[7],
            Doctor = _doctors[2],
            DateOfVisit = new DateTime(2024, 1, 5, 15, 45, 0),
            NumberOfCabinet = "315-C",
            IsAgain = false
        },
        new()
        {
            Id = 10,
            Patient = _patients[7],
            Doctor = _doctors[4],
            DateOfVisit = new DateTime(2024, 1, 8, 10, 0, 0),
            NumberOfCabinet = "308-E",
            IsAgain = true
        },
        new()
        {
            Id = 11,
            Patient = _patients[1],
            Doctor = _doctors[0],
            DateOfVisit = new DateTime(2023, 12, 30, 14, 30, 0),
            NumberOfCabinet = "101-A",
            IsAgain = true
        },
        new()
        {
            Id = 12,
            Patient = _patients[1],
            Doctor = _doctors[3],
            DateOfVisit = new DateTime(2024, 1, 18, 16, 0, 0),
            NumberOfCabinet = "112-D",
            IsAgain = false
        },
        new()
        {
            Id = 13,
            Patient = _patients[0],
            Doctor = _doctors[3],
            DateOfVisit = new DateTime(2024, 1, 18, 16, 0, 0),
            NumberOfCabinet = "111-D",
            IsAgain = false
        },
        new()
        {
            Id = 14,
            Patient = _patients[2],
            Doctor = _doctors[6],
            DateOfVisit = new DateTime(2024, 1, 18, 16, 0, 0),
            NumberOfCabinet = "121-C",
            IsAgain = false
        }
    ];
    public List<Visit> GetItems() => Visits;
    public int GetCurrentId() => 14;
}
