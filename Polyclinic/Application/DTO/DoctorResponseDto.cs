using Domain;
using System.Text.Json.Serialization;

namespace Application.DTO;

/// <summary>
/// Class describing a doctor
/// </summary>
public class DoctorResponseDto
{
    /// <summary>
    /// Field representing the doctor's passport id number
    /// </summary>
    public required int Id { get; set; }

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
    public required DateOnly Birthday { get; set; }

    /// <summary>
    /// Field representing the doctor's specialization
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Specialization? Specialization { get; set; }

    /// <summary>
    /// Field representing the doctor's work experience
    /// </summary>
    public int? WorkExperience { get; set; }
}
