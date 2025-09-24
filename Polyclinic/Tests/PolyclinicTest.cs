namespace Tests;

/// <summary>
/// Класс для юнит тестов
/// </summary>
public class PolyclinicTests : IClassFixture<PolyclinicFixture>
{
    /// <summary>
    /// Фикстура с тестовыми данными
    /// </summary>
    private readonly PolyclinicFixture _fixture;

    /// <summary>
    /// Конструктор тестового класса, инициализирующий фикстуру
    /// </summary>
    /// <param name="fixture"></param>
    public PolyclinicTests(PolyclinicFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Тест для вывода информацию о всех врачах, стаж работы которых не менее 10 лет.
    /// </summary>
    [Fact]
    public void CountOfDoctorsWhosWorkExperienceMoreOrEqyal10years()
    {
        const int excepted = 4;

        var experiencedDoctors = _fixture.Doctors
           .Where(d => d.WorkExperience >= 10)
           .ToList();

        Assert.Equal(excepted, experiencedDoctors.Count());
        Assert.Contains(experiencedDoctors, d => d.Name == "Тимофеев Олег Борисович");
        Assert.Contains(experiencedDoctors, d => d.Name == "Петров Дмитрий Викторович");
        Assert.Contains(experiencedDoctors, d => d.Name == "Сидорова Елена Михайловна");
        Assert.Contains(experiencedDoctors, d => d.Name == "Козлов Артем Игоревич");
    }

    /// <summary>
    /// Тест для вывода информацию о всех пациентах, записанных на прием к указанному врачу, упорядочить по ФИО.
    /// </summary>
    [Fact]
    public void AllPatientsToDoctorOrderedByName()
    {
        var excepted = 4; 
        var doctor = _fixture.Doctors[0].Name;

        var patients = _fixture.Visits
            .Where(v => v.Doctor.Name == doctor)
            .Select(v => v.Patient)
            .OrderBy(p => p.Name)
            .ToList();

        Assert.Equal(excepted, patients.Count());
        Assert.Equal("Иванов Петр Сидорович", patients[0].Name);
        Assert.Equal("Кузнецова Елена Сергеевна", patients[1].Name); 
        Assert.Equal("Николаев Виктор Иванович", patients[2].Name);
        Assert.Equal("Петрова Мария Ивановна", patients[3].Name);
    }

    /// <summary>
    /// Тест для вывода  информацию о количестве повторных приемов пациентов за последний месяц.
    /// </summary>
    [Fact]
    public void CountOfRepeatVisit()
    {
        const int excepted = 5;

        var lastMonth = DateTime.Now.AddMonths(-1);
        var actual = _fixture.Visits
            .Count(v => v.IsAgain == true && v.DateOfVisit >= lastMonth);

        Assert.Equal(excepted, actual);
    }

    /// <summary>
    /// Тест для вывода информацию о пациентах старше 30 лет, которые записаны на прием к нескольким врачам, упорядочить по дате рождения. 
    /// </summary>
    [Fact]
    public void AllPatientsOlder30YearsToSomeDoctorsOrderedByBirthday()
    {
        var actual = _fixture.Visits
            .GroupBy(v => v.Patient)
            .Where(d => d.Key.Birthday <= DateTime.Now.AddYears(-30))
            .Where(g => g.Select(v => v.Doctor).Distinct().Count() > 1) 
            .Select(g => g.Key)
            .OrderBy(p => p.Birthday)
            .ToList();

        Assert.Empty(actual);
    }

    /// <summary>
    /// Тест для вывода информации о приемах за текущий месяц, проходящих в выбранном кабинете.
    /// </summary>
    [Fact]
    public void AllVisitForLastMonthInSelectedCabinet()
    {
        const int excepted = 5;
        var cabinet = 101;
        var lastMonth = DateTime.Now.AddMonths(-1);

        var actual = _fixture.Visits
            .Where(v => v.IdOfCabinet == cabinet && v.DateOfVisit >= lastMonth)
            .ToList();

        Assert.Equal(excepted, actual.Count());
    }
}