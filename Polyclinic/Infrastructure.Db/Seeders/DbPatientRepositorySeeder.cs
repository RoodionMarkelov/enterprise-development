using Domain;

namespace Infrastructure.Db.Seeders;
public class DbPatientRepositorySeeder
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

    public List<Patient> GetItems() => Patients;
    public int GetCurrentId() => 10;
}
