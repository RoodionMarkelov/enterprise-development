namespace Domain;

/// <summary>
/// Enumeration of patient gender
/// </summary>
public enum Gender
{
    Male,
    Female
}

/// <summary>
/// Enumeration of patient blood group
/// </summary>
public enum BloodGroup
{
    I,
    II,
    III,
    IV
}

/// <summary>
/// Enumeration of patient Rh factor
/// </summary>
public enum RhFactor
{
    Positive,
    Negative
}

/// <summary>
/// Class describing a patient
/// </summary>
public class Patient
{
    /// <summary>
    /// Field representing the patient's passport number
    /// </summary>
    public required string IdPassport { get; set; }

    /// <summary>
    /// Field representing the patient's name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Field representing the patient's gender
    /// </summary>
    public required Gender PatientGender { get; set; }

    /// <summary>
    /// Field representing the patient's birth date
    /// </summary>
    public DateTime Birthday { get; set; }

    /// <summary>
    /// Field representing the patient's address
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Field representing the patient's blood group
    /// </summary>
    public BloodGroup? BloodGroupOfPatient { get; set; }

    /// <summary>
    /// Field representing the patient's Rh factor
    /// </summary>
    public RhFactor? RhFactorOfPatient { get; set; }

    /// <summary>
    /// Field representing the patient's phone number
    /// </summary>
    public required string Phone { get; set; }
}