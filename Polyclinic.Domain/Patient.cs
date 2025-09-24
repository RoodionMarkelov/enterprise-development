namespace Polyclinic.Domain
{
    /// <summary>
    /// Перечисление пола пациента
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    }

    /// <summary>
    /// Перечисление группы крови пациента
    /// </summary>
    public enum BloodGroup
    {
        I,
        II,
        III,
        IV
    }

    /// <summary>
    /// Перечисление резус фактора пациента
    /// </summary>
    public enum RhFactor
    {
        Positive,
        Negative
    }

    /// <summary>
    /// Класс для описания пациента
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Поле характеризующее номер паспорта пациента
        /// </summary>
        public required string IdPassport { get; set; }

        /// <summary>
        /// Поле характеризующее имя пациента
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Поле характеризующее пол пациента
        /// </summary>
        public required Gender PatientGender { get; set; }

        /// <summary>
        /// Поле характеризующее день рождения пациента
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Поле характеризующее адресс пациента
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Поле характеризующее группу крови пациента
        /// </summary>
        public BloodGroup? BloodGroupOfPatient { get; set; }

        /// <summary>
        /// Поле характеризующее резус фактор пациента
        /// </summary>
        public RhFactor? RhFactorOfPatient { get; set; }

        /// <summary>
        /// Поле характеризующее телефон пациента
        /// </summary>
        public required string Phone { get; set; }

    }
}
