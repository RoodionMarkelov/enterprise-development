namespace Domain;

/// <summary>
/// Enumeration of doctor specializations
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
/// Class describing a doctor
/// </summary>
public class Doctor
{
    /// <summary>
    /// Field representing the doctor's passport number
    /// </summary>
    public required string IdPassport { get; set; }

    /// <summary>
    /// Field representing the doctor's name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Field representing the doctor's birth date
    /// </summary>
    public DateTime Birthday { get; init; }

    /// <summary>
    /// Field representing the doctor's specialization
    /// </summary>
    public Specialization SpecializationOfDoctor { get; set; }

    /// <summary>
    /// Field representing the doctor's work experience
    /// </summary>
    public int WorkExperience { get; set; }
}