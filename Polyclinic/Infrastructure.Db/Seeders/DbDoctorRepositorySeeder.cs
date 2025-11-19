using Domain;

namespace Infrastructure.Db.Seeders;
public class DbDoctorRepositorySeeder
{
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

    public List<Doctor> GetItems() => Doctors;
    public int GetCurrentId() => 10;
}
