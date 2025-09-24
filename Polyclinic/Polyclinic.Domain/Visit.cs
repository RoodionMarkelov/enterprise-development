namespace Polyclinic.Domain;

/// <summary>
/// Класс для описания посищения пациента в поликлинику
/// </summary>
public class Visit
{
    /// <summary>
    /// Поле характеризующее пациента, записанного на приём
    /// </summary>
    public required Patient Patient { get; set; }

    /// <summary>
    /// Поле характеризующее доктора, назначенного на приём
    /// </summary>
    public required Doctor Doctor { get; set; }

    /// <summary>
    /// Поле характеризующее день записи пациента
    /// </summary>
    public DateTime DateOfVisit { get; set; }

    /// <summary>
    /// Поле характеризующее время записи пациента
    /// </summary>
    public TimeOnly TimeOfVisit { get; set; }

    /// <summary>
    /// Поле характеризующее номер кабинета
    /// </summary>
    public int IdOfCabinet { get; set; }

    /// <summary>
    /// Поле характеризующее было ли посищение повторным
    /// </summary>
    public bool IsAgain { get; set; }
}
