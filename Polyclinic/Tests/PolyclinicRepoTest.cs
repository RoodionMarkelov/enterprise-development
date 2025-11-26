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
    public async Task CountOfDoctorsWithWorkExperienceMoreOrEqual10Years()
    {
        const int expectedCount = 4;
        var expectedDoctorNames = new List<string>
        {
            "Timofeev Oleg Borisovich",
            "Petrov Dmitry Viktorovich",
            "Sidorova Elena Mikhailovna",
            "Kozlov Artem Igorevich"
        };

        var experiencedDoctors = await fixture.DoctorService.GetAllWithWorkExperienceMoreTargetAsync(10);

        Assert.Equal(expectedCount, experiencedDoctors.Count);
        Assert.Equal(expectedDoctorNames, experiencedDoctors.Select(d => d.Name));
    }

    /// <summary>
    /// Test to display information about all patients registered with a specific doctor, ordered by name
    /// </summary>
    [Fact]
    public async Task AllPatientsToDoctorOrderedByName()
    {
        const int expectedCount = 4;

        var doctors = await fixture.DoctorService.GetAllDoctorsWithIdAsync();
        var doctorId = doctors[0].Id; 

        var expectedPatientsNames = new List<string>
        {
            "Ivanov Petr Sidorovich",
            "Kuznetsova Elena Sergeevna",
            "Nikolaev Viktor Ivanovich",
            "Petrova Maria Ivanovna"
        };

        var patients = await fixture.VisitService.GetVisitsByDoctorOrderedByPatientNameAsync(doctorId);

        Assert.Equal(expectedCount, patients.Count);
        Assert.Equal(expectedPatientsNames, patients.Select(p => p.Name));
    }

    /// <summary>
    /// Test to display information about the number of follow-up patient appointments in the last month
    /// </summary>
    [Fact]
    public async Task CountOfRepeatVisitsForLastMonth()
    {
        const int expectedCount = 4;

        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        var repeatVisitsCount = await fixture.VisitService.GetCountOfRepeatVisitsForRangeOfDateAsync(startDate, endDate);

        Assert.Equal(expectedCount, repeatVisitsCount);
    }

    /// <summary>
    /// Test to display information about patients over 30 years old who are registered with multiple doctors, ordered by birth date
    /// </summary>
    [Fact]
    public async Task AllPatientsOlder30YearsToSomeDoctorsOrderedByBirthday()
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

        var experiencedPatients = await fixture.VisitService.GetAllPatientsOlderAgeToSomeDoctorsOrderedByBirthdayAsync(currentDate);

        Assert.Equal(expectedCount, experiencedPatients.Count);
        Assert.Equal(expectedPatientsNames, experiencedPatients.Select(p => p.Name));
    }

    /// <summary>
    /// Test to display information about appointments in the current month taking place in a selected cabinet
    /// </summary>
    [Fact]
    public async Task AllVisitsForLastMonthInSelectedCabinet()
    {
        const int expectedCount = 3;
        const string cabinet = "101-A";
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 31);

        var cabinetVisits = await fixture.VisitService.GetAllVisitsForDateInSelectedCabinetAsync(startDate, endDate, cabinet);

        Assert.Equal(expectedCount, cabinetVisits.Count);
    }
}