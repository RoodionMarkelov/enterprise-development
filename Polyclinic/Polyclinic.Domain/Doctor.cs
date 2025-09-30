namespace Domain;

/// <summary>
/// Class describing a doctor
/// </summary>
public class Doctor
{
    /// <summary>
    /// Field representing the doctor's passport id number
    /// </summary>
    public required int IdPassport { get; set; }

    /// <summary>
    /// Field representing the doctor's passport number
    /// </summary>
    public required string Passport { get; set; }

    /// <summary>
    /// Field representing the doctor's name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Field representing the doctor's birth date
    /// </summary>
    public required DateOnly Birthday { get; init; }

    /// <summary>
    /// Field representing the doctor's specialization
    /// </summary>
    public Specialization? Specialization { get; set; }

    /// <summary>
    /// Field representing the doctor's work experience
    /// </summary>
    public int? WorkExperience { get; set; }
}