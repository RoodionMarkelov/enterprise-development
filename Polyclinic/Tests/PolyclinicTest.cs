namespace Tests;

/// <summary>
/// Class for unit tests
/// </summary>
public class PolyclinicTests : IClassFixture<PolyclinicFixture>
{
    /// <summary>
    /// Fixture with test data
    /// </summary>
    private readonly PolyclinicFixture _fixture;

    /// <summary>
    /// Test class constructor initializing the fixture
    /// </summary>
    /// <param name="fixture"></param>
    public PolyclinicTests(PolyclinicFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Test to display information about all doctors with work experience of at least 10 years
    /// </summary>
    [Fact]
    public void CountOfDoctorsWithWorkExperienceMoreOrEqual10Years()
    {
        const int expected = 4;

        var experiencedDoctors = _fixture.Doctors
           .Where(d => d.WorkExperience >= 10)
           .ToList();

        Assert.Equal(expected, experiencedDoctors.Count);
        Assert.Contains(experiencedDoctors, d => d.Name == "Timofeev Oleg Borisovich");
        Assert.Contains(experiencedDoctors, d => d.Name == "Petrov Dmitry Viktorovich");
        Assert.Contains(experiencedDoctors, d => d.Name == "Sidorova Elena Mikhailovna");
        Assert.Contains(experiencedDoctors, d => d.Name == "Kozlov Artem Igorevich");
    }

    /// <summary>
    /// Test to display information about all patients registered with a specific doctor, ordered by name
    /// </summary>
    [Fact]
    public void AllPatientsToDoctorOrderedByName()
    {
        var expected = 4;
        var doctorName = _fixture.Doctors[0].Name;

        var patients = _fixture.Visits
            .Where(v => v.Doctor.Name == doctorName)
            .Select(v => v.Patient)
            .OrderBy(p => p.Name)
            .ToList();

        Assert.Equal(expected, patients.Count);
        Assert.Equal("Ivanov Petr Sidorovich", patients[0].Name);
        Assert.Equal("Kuznetsova Elena Sergeevna", patients[1].Name);
        Assert.Equal("Nikolaev Viktor Ivanovich", patients[2].Name);
        Assert.Equal("Petrova Maria Ivanovna", patients[3].Name);
    }

    /// <summary>
    /// Test to display information about the number of follow-up patient appointments in the last month
    /// </summary>
    [Fact]
    public void CountOfRepeatVisits()
    {
        const int expected = 5;

        var lastMonth = DateTime.Now.AddMonths(-1);
        var actual = _fixture.Visits
            .Count(v => v.IsAgain && v.DateOfVisit >= lastMonth);

        Assert.Equal(expected, actual);
    }

    /// <summary>
    /// Test to display information about patients over 30 years old who are registered with multiple doctors, ordered by birth date
    /// </summary>
    [Fact]
    public void AllPatientsOlder30YearsToSomeDoctorsOrderedByBirthday()
    {
        var actual = _fixture.Visits
            .GroupBy(v => v.Patient)
            .Where(g => g.Key.Birthday <= DateTime.Now.AddYears(-30))
            .Where(g => g.Select(v => v.Doctor).Distinct().Count() > 1)
            .Select(g => g.Key)
            .OrderBy(p => p.Birthday)
            .ToList();

        Assert.Empty(actual);
    }

    /// <summary>
    /// Test to display information about appointments in the current month taking place in a selected cabinet
    /// </summary>
    [Fact]
    public void AllVisitsForLastMonthInSelectedCabinet()
    {
        const int expected = 5;
        var cabinet = 101;
        var lastMonth = DateTime.Now.AddMonths(-1);

        var actual = _fixture.Visits
            .Where(v => v.IdOfCabinet == cabinet && v.DateOfVisit >= lastMonth)
            .ToList();

        Assert.Equal(expected, actual.Count);
    }
}