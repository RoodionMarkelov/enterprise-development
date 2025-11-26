using Domain;
using System.Text.Json.Serialization;

namespace Application.DTO;
/// <summary>
/// Class describing a patient
/// </summary>
public class PatientDto
{
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
    [JsonConverter(typeof(JsonStringEnumConverter))]
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
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BloodGroup? BloodGroup{ get; set; }

    /// <summary>
    /// Field representing the patient's Rh factor
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public RhFactor? RhFactor { get; set; }

    /// <summary>
    /// Field representing the patient's phone number
    /// </summary>
    public required string Phone { get; set; }
}