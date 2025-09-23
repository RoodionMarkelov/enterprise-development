using System.ComponentModel.DataAnnotations;

namespace Polyclinic.Domain
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum BloodGroup
    {
        I,
        II,
        III,
        IV
    }

    public enum RhFactor
    {
        Positive,
        Negative
    }
    public class Patient
    {
        public required string IdPassport { get; set; }
        public required string Name { get; set; }
        public required Gender PatientGender { get; set; }
        public DateTime Birthday { get; set; }
        public string? Address { get; set; }
        public BloodGroup? BloodGroup { get; set; }
        public RhFactor? RhFactor { get; set; }
        public required string Phone { get; set; }

    }
}
