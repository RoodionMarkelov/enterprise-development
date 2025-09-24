namespace Polyclinic.Domain;

/// <summary>
/// Перечисление специализаций врачей
/// </summary>
public enum Specialization
{
    Therapist,
    Surgeon,
    Cardiologist,
    Neurologist,
    Pediatrician,
    Dentist,
    Ophthalmologist,
    Dermatologist,
    Orthopedist,
}

/// <summary>
/// Класс для описания доктора
/// </summary>
public class Doctor
{
    /// <summary>
    /// Поле характеризующее номер паспорта доктора
    /// </summary>
    public required string IdPassport { get; set; }

    /// <summary>
    ///  Поле характеризующее имя доктора
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Поле характерезующее дату дня рождения доктора
    /// </summary>
    public DateTime Birthday { get; init; }

    /// <summary>
    /// Поле характерезующее специализацию доктора
    /// </summary>
    public Specialization SpecializationOfDoctor { get; set; }

    /// <summary>
    /// Поле характерезующее стаж доктора
    /// </summary>
    public int WorkExperience { get; set; }

}