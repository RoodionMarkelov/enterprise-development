namespace Domain;

/// <summary>
/// Class describing a patient's visit to the polyclinic
/// </summary>
public class Visit
{
    /// <summary>
    /// Field representing the patient scheduled for the appointment
    /// </summary>
    public required Patient Patient { get; set; }

    /// <summary>
    /// Field representing the doctor assigned to the appointment
    /// </summary>
    public required Doctor Doctor { get; set; }

    /// <summary>
    /// Field representing the date of the patient's appointment
    /// </summary>
    public DateTime DateOfVisit { get; set; }

    /// <summary>
    /// Field representing the cabinet number
    /// </summary>
    public required string NumberOfCabinet { get; set; }

    /// <summary>
    /// Field representing whether the visit was a follow-up
    /// </summary>
    public bool IsAgain { get; set; }
}