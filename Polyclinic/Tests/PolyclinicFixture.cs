using Domain;

namespace Tests;

/// <summary>
/// Class with data for unit tests
/// </summary>
public class PolyclinicFixture
{
    /// <summary>
    /// List of all patients
    /// </summary>
    public List<Patient> Patients =>
        [
            new()
            {
                IdPassport = "2003 256748",
                Name = "Ivanov Petr Sidorovich",
                PatientGender = Gender.Male,
                Birthday = DateTime.Now.AddYears(-35),
                Address = "Moscow, Sadovaya st., 147, apt. 1",
                BloodGroupOfPatient = BloodGroup.I,
                RhFactorOfPatient = RhFactor.Positive,
                Phone = "+79371234567"
            },
            new()
            {
                IdPassport = "2015 123456",
                Name = "Petrova Maria Ivanovna",
                PatientGender = Gender.Female,
                Birthday = DateTime.Now.AddYears(-28),
                Address = "St. Petersburg, Lenina st., 25, apt. 45",
                BloodGroupOfPatient = BloodGroup.II,
                RhFactorOfPatient = RhFactor.Positive,
                Phone = "+79161234567"
            },
            new()
            {
                IdPassport = "1998 654321",
                Name = "Sidorov Andrey Vladimirovich",
                PatientGender = Gender.Male,
                Birthday = DateTime.Now.AddYears(-42),
                Address = "Novosibirsk, Tsentralnaya st., 10, apt. 12",
                BloodGroupOfPatient = BloodGroup.III,
                RhFactorOfPatient = RhFactor.Negative,
                Phone = "+79031234567"
            },
            new()
            {
                IdPassport = "2010 987654",
                Name = "Kuznetsova Elena Sergeevna",
                PatientGender = Gender.Female,
                Birthday = DateTime.Now.AddYears(-31),
                Address = "Yekaterinburg, Pushkina st., 33, apt. 78",
                BloodGroupOfPatient = BloodGroup.IV,
                RhFactorOfPatient = RhFactor.Positive,
                Phone = "+79261234567"
            },
            new()
            {
                IdPassport = "2005 456789",
                Name = "Smirnov Alexey Petrovich",
                PatientGender = Gender.Male,
                Birthday = DateTime.Now.AddYears(-25),
                Address = "Kazan, Gagarina st., 15, apt. 23",
                BloodGroupOfPatient = BloodGroup.I,
                RhFactorOfPatient = RhFactor.Negative,
                Phone = "+79501234567"
            },
            new()
            {
                IdPassport = "2018 321654",
                Name = "Vasilyeva Olga Dmitrievna",
                PatientGender = Gender.Female,
                Birthday = DateTime.Now.AddYears(-19),
                Address = "Nizhny Novgorod, Sovetskaya st., 47, apt. 56",
                BloodGroupOfPatient = BloodGroup.II,
                RhFactorOfPatient = RhFactor.Negative,
                Phone = "+79991234567"
            },
            new()
            {
                IdPassport = "1975 111111",
                Name = "Nikolaev Viktor Ivanovich",
                PatientGender = Gender.Male,
                Birthday = DateTime.Now.AddYears(-50),
                Address = "Moscow, Tsentralnaya st., 10",
                BloodGroupOfPatient = BloodGroup.II,
                RhFactorOfPatient = RhFactor.Positive,
                Phone = "+79111111111"
            },
            new()
            {
                IdPassport = "1980 222222",
                Name = "Orlova Svetlana Petrovna",
                PatientGender = Gender.Female,
                Birthday = DateTime.Now.AddYears(-43),
                Address = "St. Petersburg, Nevsky pr., 25",
                BloodGroupOfPatient = BloodGroup.III,
                RhFactorOfPatient = RhFactor.Negative,
                Phone = "+79222222222"
            },
            new()
            {
                IdPassport = "1742 123575",
                Name = "Olegov Svetoslav Petrovich",
                PatientGender = Gender.Male,
                Birthday = DateTime.Now.AddYears(-20),
                Address = "St. Petersburg, Nevsky pr., 40",
                BloodGroupOfPatient = BloodGroup.II,
                RhFactorOfPatient = RhFactor.Negative,
                Phone = "+79133546362"
            },
            new()
            {
                IdPassport = "1980 222222",
                Name = "Revenkova Olga Igorevna",
                PatientGender = Gender.Female,
                Birthday = DateTime.Now.AddYears(-20),
                Address = "St. Petersburg, Nevsky pr., 120",
                BloodGroupOfPatient = BloodGroup.I,
                RhFactorOfPatient = RhFactor.Negative,
                Phone = "+79123456123"
            }
        ];

    /// <summary>
    /// List of all doctors
    /// </summary>
    public List<Doctor> Doctors =>
        [
            new() {
                IdPassport = "1223 456782",
                Name = "Timofeev Oleg Borisovich",
                Birthday = DateTime.Now.AddYears(-40),
                SpecializationOfDoctor = Specialization.Therapist,
                WorkExperience = 10
            },
            new() {
                IdPassport = "1234 567893",
                Name = "Ivanova Anna Sergeevna",
                Birthday = DateTime.Now.AddYears(-35),
                SpecializationOfDoctor = Specialization.Cardiologist,
                WorkExperience = 8
            },
            new() {
                IdPassport = "1345 678904",
                Name = "Petrov Dmitry Viktorovich",
                Birthday = DateTime.Now.AddYears(-45),
                SpecializationOfDoctor = Specialization.Surgeon,
                WorkExperience = 15
            },
            new() {
                IdPassport = "1456 789015",
                Name = "Sidorova Elena Mikhailovna",
                Birthday = DateTime.Now.AddYears(-38),
                SpecializationOfDoctor = Specialization.Pediatrician,
                WorkExperience = 12
            },
            new() {
                IdPassport = "1567 890126",
                Name = "Kozlov Artem Igorevich",
                Birthday = DateTime.Now.AddYears(-42),
                SpecializationOfDoctor = Specialization.Neurologist,
                WorkExperience = 14
            },
            new() {
                IdPassport = "1678 901237",
                Name = "Fedorov Sergey Vasilyevich",
                Birthday = DateTime.Now.AddYears(-48),
                SpecializationOfDoctor = Specialization.Dentist,
                WorkExperience = 9
            },
            new() {
                IdPassport = "2465 436678",
                Name = "Fedorov Ivan Vasilyevich",
                Birthday = DateTime.Now.AddYears(-67),
                SpecializationOfDoctor = Specialization.Dentist,
                WorkExperience = 4
            },
            new() {
                IdPassport = "9999 9999",
                Name = "Fedorov Oleg Vasilyevich",
                Birthday = DateTime.Now.AddYears(-30),
                SpecializationOfDoctor = Specialization.Dentist,
                WorkExperience = 1
            },
            new() {
                IdPassport = "6666 666666",
                Name = "Fedorov Petr Vasilyevich",
                Birthday = DateTime.Now.AddYears(-29),
                SpecializationOfDoctor = Specialization.Dentist,
                WorkExperience = 4
            },
            new() {
                IdPassport = "7777 777771",
                Name = "Fedorov Kirill Vasilyevich",
                Birthday = DateTime.Now.AddYears(-28),
                SpecializationOfDoctor = Specialization.Dentist,
                WorkExperience = 2
            }
        ];

    /// <summary>
    /// List of all appointments
    /// </summary>
    public List<Visit> Visits =>
        [
            new() {
                Patient = Patients[0],
                Doctor = Doctors[0],
                DateOfVisit = DateTime.Now.AddDays(-5),
                TimeOfVisit = new TimeOnly(10, 30),
                IdOfCabinet = 101,
                IsAgain = false
            },
            new() {
                Patient = Patients[1],
                Doctor = Doctors[1],
                DateOfVisit = DateTime.Now.AddDays(-3),
                TimeOfVisit = new TimeOnly(14, 15),
                IdOfCabinet = 205,
                IsAgain = true
            },
            new() {
                Patient = Patients[4],
                Doctor = Doctors[2],
                DateOfVisit = DateTime.Now.AddDays(-1),
                TimeOfVisit = new TimeOnly(9, 0),
                IdOfCabinet = 315,
                IsAgain = false
            },
            new() {
                Patient = Patients[5],
                Doctor = Doctors[3],
                DateOfVisit = DateTime.Now.AddDays(2),
                TimeOfVisit = new TimeOnly(11, 45),
                IdOfCabinet = 112,
                IsAgain = false
            },
            new() {
                Patient = Patients[2],
                Doctor = Doctors[4],
                DateOfVisit = DateTime.Now.AddDays(-7),
                TimeOfVisit = new TimeOnly(16, 20),
                IdOfCabinet = 308,
                IsAgain = true
            },
            new() {
                Patient = Patients[3],
                Doctor = Doctors[0],
                DateOfVisit = DateTime.Now.AddDays(1),
                TimeOfVisit = new TimeOnly(13, 0),
                IdOfCabinet = 101,
                IsAgain = false
            },
            new() {
                Patient = Patients[6],
                Doctor = Doctors[0],
                DateOfVisit = DateTime.Now.AddDays(-10),
                TimeOfVisit = new TimeOnly(11, 0),
                IdOfCabinet = 101,
                IsAgain = false
            },
            new() {
                Patient = Patients[6],
                Doctor = Doctors[1],
                DateOfVisit = DateTime.Now.AddDays(-8),
                TimeOfVisit = new TimeOnly(15, 30),
                IdOfCabinet = 205,
                IsAgain = true
            },
            new() {
                Patient = Patients[7],
                Doctor = Doctors[2],
                DateOfVisit = DateTime.Now.AddDays(-15),
                TimeOfVisit = new TimeOnly(9, 45),
                IdOfCabinet = 315,
                IsAgain = false
            },
            new() {
                Patient = Patients[7],
                Doctor = Doctors[4],
                DateOfVisit = DateTime.Now.AddDays(-12),
                TimeOfVisit = new TimeOnly(14, 0),
                IdOfCabinet = 308,
                IsAgain = true
            },
            new() {
                Patient = Patients[1],
                Doctor = Doctors[0],
                DateOfVisit = DateTime.Now.AddDays(-20),
                TimeOfVisit = new TimeOnly(16, 0),
                IdOfCabinet = 101,
                IsAgain = true
            },
            new() {
                Patient = Patients[1],
                Doctor = Doctors[3],
                DateOfVisit = DateTime.Now.AddDays(-2),
                TimeOfVisit = new TimeOnly(10, 0),
                IdOfCabinet = 101,
                IsAgain = false
            }
        ];
}