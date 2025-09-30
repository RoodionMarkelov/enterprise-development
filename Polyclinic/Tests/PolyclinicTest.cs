namespace Tests;

/// <summary>
/// Class for unit tests
/// </summary>
/// <param name="fixture">Fixture with test data</param>
public class PolyclinicTests(PolyclinicFixture fixture) : IClassFixture<PolyclinicFixture>
{
    /// <summary>
    /// Test to display information about all doctors with work experience of at least 10 years
    /// </summary>
    [Fact]
    public void CountOfDoctorsWithWorkExperienceMoreOrEqual10Years()
    {
        const int expectedCount = 4;
        var expectedDoctorNames = new List<string>
        {
            "Timofeev Oleg Borisovich",
            "Petrov Dmitry Viktorovich",
            "Sidorova Elena Mikhailovna",
            "Kozlov Artem Igorevich"
        };

        var experiencedDoctors = fixture.Doctors
           .Where(d => d.WorkExperience >= 10)
           .ToList();

        Assert.Equal(expectedCount, experiencedDoctors.Count);
        Assert.Equal(expectedDoctorNames, experiencedDoctors.Select(d => d.Name));
    }

    /// <summary>
    /// Test to display information about all patients registered with a specific doctor, ordered by name
    /// </summary>
    [Fact]
    public void AllPatientsToDoctorOrderedByName()
    {
        const int expectedCount = 4;
        var doctorId = fixture.Doctors[0].IdPassport;
        var expectedPatientsNames = new List<string>
        {
            "Ivanov Petr Sidorovich",
            "Kuznetsova Elena Sergeevna",
            "Nikolaev Viktor Ivanovich",
            "Petrova Maria Ivanovna"
        };

        var experiencedPatients = fixture.Visits
            .Where(v => v.Doctor.IdPassport == doctorId)
            .Select(v => v.Patient)
            .OrderBy(p => p.Name)
            .ToList();

        Assert.Equal(expectedCount, experiencedPatients.Count);
        Assert.Equal(expectedPatientsNames, experiencedPatients.Select(d => d.Name));
    }

    /// <summary>
    /// Test to display information about the number of follow-up patient appointments in the last month
    /// </summary>
    [Fact]
    public void CountOfRepeatVisitsForLastMonth()
    {
        const int expectedCount = 4;

        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        var experiencedRepeat = fixture.Visits
            .Count(v => v.IsAgain && v.DateOfVisit >= startDate && v.DateOfVisit <= endDate);

        Assert.Equal(expectedCount, experiencedRepeat);
    }

    /// <summary>
    /// Test to display information about patients over 30 years old who are registered with multiple doctors, ordered by birth date
    /// </summary>
    [Fact]
    public void AllPatientsOlder30YearsToSomeDoctorsOrderedByBirthday()
    {
        const int expectedCount = 5;
        var currentData = new DateOnly(1994, 1, 1);
        var expectedPatientsNames = new List<string>
        {
            "Nikolaev Viktor Ivanovich",
            "Orlova Svetlana Petrovna",
            "Sidorov Andrey Vladimirovich",
            "Ivanov Petr Sidorovich",
            "Petrova Maria Ivanovna"
        };

        var experiencedPatients = fixture.Visits
            .GroupBy(v => v.Patient.IdPassport)
            .Select(g => new
            {
                PatientId = g.Key,
                Patient = fixture.Patients.First(p => p.IdPassport == g.Key),
                UniqueDoctors = g.Select(v => v.Doctor.IdPassport).Distinct().Count()
            })
            .Where(x => x.Patient.Birthday <= currentData && x.UniqueDoctors > 1)
            .Select(x => x.Patient)
            .OrderBy(p => p.Birthday)
            .ToList();

        Assert.Equal(expectedCount, experiencedPatients.Count);
        Assert.Equal(expectedPatientsNames, experiencedPatients.Select(d => d.Name));
    }

    /// <summary>
    /// Test to display information about appointments in the current month taking place in a selected cabinet
    /// </summary>
    [Fact]
    public void AllVisitsForLastMonthInSelectedCabinet()
    {
        const int expectedCount = 3;
        const string cabinet = "101-A";
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        var experiencedVisit = fixture.Visits
            .Where(v => v.NumberOfCabinet == cabinet && v.DateOfVisit >= startDate && v.DateOfVisit <= endDate)
            .ToList();

        Assert.Equal(expectedCount, experiencedVisit.Count);
    }
}