namespace Domain.Seeder;

/// <summary>
/// Class with data about entitys
/// </summary>
public class DataSeeder
{
    /// <summary>
    /// List of all patients
    /// </summary>
    public List<Patient> Patients =>
    [
        new()
        {
            Id = 1,
            Passport = "2003 256748",
            Name = "Ivanov Petr Sidorovich",
            Gender = Gender.Male,
            Birthday = new DateOnly(1989, 5, 15),
            Address = "Moscow, Sadovaya st., 147, apt. 1",
            BloodGroup = BloodGroup.I,
            RhFactor = RhFactor.Positive,
            Phone = "+79371234567"
        },
        new()
        {
            Id = 2,
            Passport = "2015 123456",
            Name = "Petrova Maria Ivanovna",
            Gender = Gender.Female,
            Birthday = new DateOnly(1992, 8, 22),
            Address = "St. Petersburg, Lenina st., 25, apt. 45",
            BloodGroup = BloodGroup.II,
            RhFactor = RhFactor.Positive,
            Phone = "+79161234567"
        },
        new()
        {
            Id = 3,
            Passport = "1998 654321",
            Name = "Sidorov Andrey Vladimirovich",
            Gender = Gender.Male,
            Birthday = new DateOnly(1982, 3, 10),
            Address = "Novosibirsk, Tsentralnaya st., 10, apt. 12",
            BloodGroup = BloodGroup.III,
            RhFactor = RhFactor.Negative,
            Phone = "+79031234567"
        },
        new()
        {
            Id = 4,
            Passport = "2010 987654",
            Name = "Kuznetsova Elena Sergeevna",
            Gender = Gender.Female,
            Birthday = new DateOnly(1993, 11, 30),
            Address = "Yekaterinburg, Pushkina st., 33, apt. 78",
            BloodGroup = BloodGroup.IV,
            RhFactor = RhFactor.Positive,
            Phone = "+79261234567"
        },
        new()
        {
            Id = 5,
            Passport = "2005 456789",
            Name = "Smirnov Alexey Petrovich",
            Gender = Gender.Male,
            Birthday = new DateOnly(1999, 7, 5),
            Address = "Kazan, Gagarina st., 15, apt. 23",
            BloodGroup = BloodGroup.I,
            RhFactor = RhFactor.Negative,
            Phone = "+79501234567"
        },
        new()
        {
            Id = 6,
            Passport = "2018 321654",
            Name = "Vasilyeva Olga Dmitrievna",
            Gender = Gender.Female,
            Birthday = new DateOnly(2005, 2, 14),
            Address = "Nizhny Novgorod, Sovetskaya st., 47, apt. 56",
            BloodGroup = BloodGroup.II,
            RhFactor = RhFactor.Negative,
            Phone = "+79991234567"
        },
        new()
        {
            Id = 7,
            Passport = "1975 111111",
            Name = "Nikolaev Viktor Ivanovich",
            Gender = Gender.Male,
            Birthday = new DateOnly(1974, 12, 5),
            Address = "Moscow, Tsentralnaya st., 10",
            BloodGroup = BloodGroup.II,
            RhFactor = RhFactor.Positive,
            Phone = "+79111111111"
        },
        new()
        {
            Id = 8,
            Passport = "1980 222222",
            Name = "Orlova Svetlana Petrovna",
            Gender = Gender.Female,
            Birthday = new DateOnly(1981, 9, 18),
            Address = "St. Petersburg, Nevsky pr., 25",
            BloodGroup = BloodGroup.III,
            RhFactor = RhFactor.Negative,
            Phone = "+79222222222"
        },
        new()
        {
            Id = 9,
            Passport = "1742 123575",
            Name = "Olegov Svetoslav Petrovich",
            Gender = Gender.Male,
            Birthday = new DateOnly(2004, 4, 25),
            Address = "St. Petersburg, Nevsky pr., 40",
            BloodGroup = BloodGroup.II,
            RhFactor = RhFactor.Negative,
            Phone = "+79133546362"
        },
        new()
        {
            Id = 10,
            Passport = "1980 222223",
            Name = "Revenkova Olga Igorevna",
            Gender = Gender.Female,
            Birthday = new DateOnly(2004, 6, 12),
            Address = "St. Petersburg, Nevsky pr., 120",
            BloodGroup = BloodGroup.I,
            RhFactor = RhFactor.Negative,
            Phone = "+79123456123"
        }
    ];

    /// <summary>
    /// List of all doctors
    /// </summary>
    public List<Doctor> Doctors =>
    [
        new()
        {
            Id = 1,
            Passport = "1223 456782",
            Name = "Timofeev Oleg Borisovich",
            Birthday = new DateOnly(1984, 1, 20),
            Specialization = Specialization.Therapist,
            WorkExperience = 10
        },
        new()
        {
            Id = 2,
            Passport = "1234 567893",
            Name = "Ivanova Anna Sergeevna",
            Birthday = new DateOnly(1989, 7, 15),
            Specialization = Specialization.Cardiologist,
            WorkExperience = 8
        },
        new()
        {
            Id = 3,
            Passport = "1345 678904",
            Name = "Petrov Dmitry Viktorovich",
            Birthday = new DateOnly(1979, 3, 8),
            Specialization = Specialization.Surgeon,
            WorkExperience = 15
        },
        new()
        {
            Id = 4,
            Passport = "1456 789015",
            Name = "Sidorova Elena Mikhailovna",
            Birthday = new DateOnly(1986, 11, 25),
            Specialization = Specialization.Pediatrician,
            WorkExperience = 12
        },
        new()
        {
            Id = 5,
            Passport = "1567 890126",
            Name = "Kozlov Artem Igorevich",
            Birthday = new DateOnly(1982, 5, 30),
            Specialization = Specialization.Neurologist,
            WorkExperience = 14
        },
        new()
        {
            Id = 6,
            Passport = "1678 901237",
            Name = "Fedorov Sergey Vasilyevich",
            Birthday = new DateOnly(1976, 8, 12),
            Specialization = Specialization.Dentist,
            WorkExperience = 9
        },
        new()
        {
            Id = 7,
            Passport = "2465 436678",
            Name = "Fedorov Ivan Vasilyevich",
            Birthday = new DateOnly(1957, 2, 28),
            Specialization = Specialization.Dentist,
            WorkExperience = 4
        },
        new()
        {
            Id = 8,
            Passport = "9999 999999",
            Name = "Fedorov Oleg Vasilyevich",
            Birthday = new DateOnly(1994, 10, 5),
            Specialization = Specialization.Dentist,
            WorkExperience = 1
        },
        new()
        {
            Id = 9,
            Passport = "6666 666666",
            Name = "Fedorov Petr Vasilyevich",
            Birthday = new DateOnly(1995, 12, 15),
            Specialization = Specialization.Dentist,
            WorkExperience = 4
        },
        new()
        {
            Id = 10,
            Passport = "7777 777771",
            Name = "Fedorov Kirill Vasilyevich",
            Birthday = new DateOnly(1996, 4, 3),
            Specialization = Specialization.Dentist,
            WorkExperience = 2
        }
    ];

    /// <summary>
    /// List of all appointments
    /// </summary>
    public List<Visit> Visits =>
    [
        new()
        {
            Id = 1,
            Patient = Patients[0],
            PatientId = Patients[0].Id,
            Doctor = Doctors[0],
            DoctorId = Doctors[0].Id,
            DateOfVisit = new DateTime(2024, 1, 15, 10, 30, 0),
            NumberOfCabinet = "101-A",
            IsAgain = false
        },
        new()
        {
            Id = 2,
            Patient = Patients[1],
            PatientId = Patients[1].Id,
            Doctor = Doctors[1],
            DoctorId = Doctors[1].Id,
            DateOfVisit = new DateTime(2024, 1, 17, 14, 15, 0),
            NumberOfCabinet = "205-B",
            IsAgain = true
        },
        new()
        {
            Id = 3,
            Patient = Patients[4],
            PatientId = Patients[4].Id,
            Doctor = Doctors[2],
            DoctorId = Doctors[2].Id,
            DateOfVisit = new DateTime(2024, 1, 19, 9, 0, 0),
            NumberOfCabinet = "315-C",
            IsAgain = false
        },
        new()
        {
            Id = 4,
            Patient = Patients[5],
            PatientId = Patients[5].Id,
            Doctor = Doctors[3],
            DoctorId = Doctors[3].Id,
            DateOfVisit = new DateTime(2024, 1, 22, 11, 45, 0),
            NumberOfCabinet = "112-D",
            IsAgain = false
        },
        new()
        {
            Id = 5,
            Patient = Patients[2],
            PatientId = Patients[2].Id,
            Doctor = Doctors[4],
            DoctorId = Doctors[4].Id,
            DateOfVisit = new DateTime(2024, 1, 13, 16, 20, 0),
            NumberOfCabinet = "308-E",
            IsAgain = true
        },
        new()
        {
            Id = 6,
            Patient = Patients[3],
            PatientId = Patients[3].Id,
            Doctor = Doctors[0],
            DoctorId = Doctors[0].Id,
            DateOfVisit = new DateTime(2024, 1, 21, 13, 0, 0),
            NumberOfCabinet = "101-A",
            IsAgain = false
        },
        new()
        {
            Id = 7,
            Patient = Patients[6],
            PatientId = Patients[6].Id,
            Doctor = Doctors[0],
            DoctorId = Doctors[0].Id,
            DateOfVisit = new DateTime(2024, 1, 10, 9, 15, 0),
            NumberOfCabinet = "101-A",
            IsAgain = false
        },
        new()
        {
            Id = 8,
            Patient = Patients[6],
            PatientId = Patients[6].Id,
            Doctor = Doctors[1],
            DoctorId = Doctors[1].Id,
            DateOfVisit = new DateTime(2024, 1, 12, 11, 30, 0),
            NumberOfCabinet = "205-B",
            IsAgain = true
        },
        new()
        {
            Id = 9,
            Patient = Patients[7],
            PatientId = Patients[7].Id,
            Doctor = Doctors[2],
            DoctorId = Doctors[2].Id,
            DateOfVisit = new DateTime(2024, 1, 5, 15, 45, 0),
            NumberOfCabinet = "315-C",
            IsAgain = false
        },
        new()
        {
            Id = 10,
            Patient = Patients[7],
            PatientId = Patients[7].Id,
            Doctor = Doctors[4],
            DoctorId = Doctors[4].Id,
            DateOfVisit = new DateTime(2024, 1, 8, 10, 0, 0),
            NumberOfCabinet = "308-E",
            IsAgain = true
        },
        new()
        {
            Id = 11,
            Patient = Patients[1],
            PatientId = Patients[1].Id,
            Doctor = Doctors[0],
            DoctorId = Doctors[0].Id,
            DateOfVisit = new DateTime(2023, 12, 30, 14, 30, 0),
            NumberOfCabinet = "101-A",
            IsAgain = true
        },
        new()
        {
            Id = 12,
            Patient = Patients[1],
            PatientId = Patients[1].Id,
            Doctor = Doctors[3],
            DoctorId = Doctors[3].Id,
            DateOfVisit = new DateTime(2024, 1, 18, 16, 0, 0),
            NumberOfCabinet = "112-D",
            IsAgain = false
        },
        new()
        {
            Id = 13,
            Patient = Patients[0],
            PatientId = Patients[0].Id,
            Doctor = Doctors[3],
            DoctorId = Doctors[3].Id,
            DateOfVisit = new DateTime(2024, 1, 18, 16, 0, 0),
            NumberOfCabinet = "111-D",
            IsAgain = false
        },
        new()
        {
            Id = 14,
            Patient = Patients[2],
            PatientId = Patients[2].Id,
            Doctor = Doctors[6],
            DoctorId = Doctors[6].Id,
            DateOfVisit = new DateTime(2024, 1, 18, 16, 0, 0),
            NumberOfCabinet = "121-C",
            IsAgain = false
        }
    ];
}
