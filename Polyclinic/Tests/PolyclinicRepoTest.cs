namespace Tests;

/// <summary>
/// Class for unit tests using services
/// </summary>
/// <param name="fixture">Fixture with services</param>
public class PolyclinicRepoTests(PolyclinicRepoFixture fixture) : IClassFixture<PolyclinicRepoFixture>
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

        var experiencedDoctors = fixture.DoctorService.GetAllWhithWorkExperienceMoreTarget(10);

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

        var doctors = fixture.DoctorService.GetAll();
        var doctorId = doctors[0].Id;

        var expectedPatientsNames = new List<string>
        {
            "Ivanov Petr Sidorovich",
            "Kuznetsova Elena Sergeevna",
            "Nikolaev Viktor Ivanovich",
            "Petrova Maria Ivanovna"
        };

        var doctorVisits = fixture.VisitService.GetVisitsByDoctorOrderedByPatientName(doctorId);

        Assert.Equal(expectedCount, doctorVisits.Count);
        Assert.Equal(expectedPatientsNames, doctorVisits.Select(p => p.Name));
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

        var repeatVisitsCount = fixture.VisitService.GetCountOfRepeatVisitsForRangeOfDate(startDate, endDate);

        Assert.Equal(expectedCount, repeatVisitsCount);
    }

    /// <summary>
    /// Test to display information about patients over 30 years old who are registered with multiple doctors, ordered by birth date
    /// </summary>
    [Fact]
    public void AllPatientsOlder30YearsToSomeDoctorsOrderedByBirthday()
    {
        const int expectedCount = 5;
        var currentDate = new DateOnly(2025, 10, 3);
        var expectedPatientsNames = new List<string>
        {
            "Nikolaev Viktor Ivanovich",
            "Orlova Svetlana Petrovna",
            "Sidorov Andrey Vladimirovich",
            "Ivanov Petr Sidorovich",
            "Petrova Maria Ivanovna"
        };

        var experiencedPatients = fixture.VisitService.GetAllPatientsOlderAgeToSomeDoctorsOrderedByBirthday(currentDate);

        Assert.Equal(expectedCount, experiencedPatients.Count);
        Assert.Equal(expectedPatientsNames, experiencedPatients.Select(p => p.Name));
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

        var cabinetVisits = fixture.VisitService.GetAllVisitsForDateInSelectedCabinet(startDate, endDate, cabinet);

        Assert.Equal(expectedCount, cabinetVisits.Count);
    }
}