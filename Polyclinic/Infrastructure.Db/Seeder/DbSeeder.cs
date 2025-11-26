using Domain;
using Domain.Seeder;

namespace Infrastructure.Db.Seeder;

/// <summary>
/// Class with data about entitys for DataBase
/// </summary>
public class DbSeeder
{
    /// <summary>
    /// List of all patients
    /// </summary>
    public List<Patient> Patients => new DataSeeder().Patients;

    /// <summary>
    /// List of all doctors
    /// </summary>
    public List<Doctor> Doctors => new DataSeeder().Doctors;

    /// <summary>
    /// List of all appointments
    /// </summary>
    public List<object> Visits =>
       [
            new
            {
                Id = 1,
                PatientId = Patients[0].Id,
                DoctorId = Doctors[0].Id,
                DateOfVisit = new DateTime(2024, 1, 15, 10, 30, 0),
                NumberOfCabinet = "101-A",
                IsAgain = false
            },
            new
            {
                Id = 2,
                PatientId = Patients[1].Id,
                DoctorId = Doctors[1].Id,
                DateOfVisit = new DateTime(2024, 1, 17, 14, 15, 0),
                NumberOfCabinet = "205-B",
                IsAgain = true
            },
            new
            {
                Id = 3,
                PatientId = Patients[4].Id,
                DoctorId = Doctors[2].Id,
                DateOfVisit = new DateTime(2024, 1, 19, 9, 0, 0),
                NumberOfCabinet = "315-C",
                IsAgain = false
            },
            new
            {
                Id = 4,
                PatientId = Patients[5].Id,
                DoctorId = Doctors[3].Id,
                DateOfVisit = new DateTime(2024, 1, 22, 11, 45, 0),
                NumberOfCabinet = "112-D",
                IsAgain = false
            },
            new
            {
                Id = 5,
                PatientId = Patients[2].Id,
                DoctorId = Doctors[4].Id,
                DateOfVisit = new DateTime(2024, 1, 13, 16, 20, 0),
                NumberOfCabinet = "308-E",
                IsAgain = true
            },
            new
            {
                Id = 6,
                PatientId = Patients[3].Id,
                DoctorId = Doctors[0].Id,
                DateOfVisit = new DateTime(2024, 1, 21, 13, 0, 0),
                NumberOfCabinet = "101-A",
                IsAgain = false
            },
            new
            {
                Id = 7,
                PatientId = Patients[6].Id,
                DoctorId = Doctors[0].Id,
                DateOfVisit = new DateTime(2024, 1, 10, 9, 15, 0),
                NumberOfCabinet = "101-A",
                IsAgain = false
            },
            new
            {
                Id = 8,
                PatientId = Patients[6].Id,
                DoctorId = Doctors[1].Id,
                DateOfVisit = new DateTime(2024, 1, 12, 11, 30, 0),
                NumberOfCabinet = "205-B",
                IsAgain = true
            },
            new
            {
                Id = 9,
                PatientId = Patients[7].Id,
                DoctorId = Doctors[2].Id,
                DateOfVisit = new DateTime(2024, 1, 5, 15, 45, 0),
                NumberOfCabinet = "315-C",
                IsAgain = false
            },
            new
            {
                Id = 10,
                PatientId = Patients[7].Id,
                DoctorId = Doctors[4].Id,
                DateOfVisit = new DateTime(2024, 1, 8, 10, 0, 0),
                NumberOfCabinet = "308-E",
                IsAgain = true
            },
            new
            {
                Id = 11,
                PatientId = Patients[1].Id,
                DoctorId = Doctors[0].Id,
                DateOfVisit = new DateTime(2023, 12, 30, 14, 30, 0),
                NumberOfCabinet = "101-A",
                IsAgain = true
            },
            new
            {
                Id = 12,
                PatientId = Patients[1].Id,
                DoctorId = Doctors[3].Id,
                DateOfVisit = new DateTime(2024, 1, 18, 16, 0, 0),
                NumberOfCabinet = "112-D",
                IsAgain = false
            },
            new
            {
                Id = 13,
                PatientId = Patients[0].Id,
                DoctorId = Doctors[3].Id,
                DateOfVisit = new DateTime(2024, 1, 18, 16, 0, 0),
                NumberOfCabinet = "111-D",
                IsAgain = false
            },
            new
            {
                Id = 14,
                PatientId = Patients[2].Id,
                DoctorId = Doctors[6].Id,
                DateOfVisit = new DateTime(2024, 1, 18, 16, 0, 0),
                NumberOfCabinet = "121-C",
                IsAgain = false
            }
       ];
}
