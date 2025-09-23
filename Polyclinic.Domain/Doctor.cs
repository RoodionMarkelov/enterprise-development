using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.Domain
{
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

    public class Doctor
    {
        public required string IdPassport { get; set; }
        public required string Name { get; set; }
        public DateTime Birthday { get; init; }
        public Specialization SpecializationOfDoctor { get; set; }
        public int WorkExperience { get; set; }

    }
}