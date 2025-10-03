namespace Domain;

/// <summary>
/// Class describing a patient
/// </summary>
public class Patient
{
    /// <summary>
    /// Field representing the patient's passport id number
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Field representing the patient's passport number
    /// </summary>
    public required string Passport { get; set; }

    /// <summary>
    /// Field representing the patient's name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Field representing the patient's gender
    /// </summary>
    public required Gender Gender { get; set; }

    /// <summary>
    /// Field representing the patient's birth date
    /// </summary>
    public required DateOnly Birthday { get; set; }

    /// <summary>
    /// Field representing the patient's address
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Field representing the patient's blood group
    /// </summary>
    public BloodGroup? BloodGroup { get; set; }

    /// <summary>
    /// Field representing the patient's Rh factor
    /// </summary>
    public RhFactor? RhFactor { get; set; }

    /// <summary>
    /// Field representing the patient's phone number
    /// </summary>
    public required string Phone { get; set; }
}