using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Polyclinic.Domain;

namespace Polyclinic.Test
{
    public class PolyclinicFixture
    {
        public List<Patient> Patients =>
            [
                new()
                {
                    IdPassport = "2003 256748",
                    Name = "Иванов Петр Сидорович",
                    PatientGender = Gender.Male,
                    Birthday = DateTime.Now.AddYears(-35),
                    Address = "г. Москва, ул.Садовая, дом.147, кв.1",
                    BloodGroupOfPatient = BloodGroup.I,
                    RhFactorOfPatient = RhFactor.Positive,
                    Phone = "+79371234567"
                },
                new()
                {
                    IdPassport = "2015 123456",
                    Name = "Петрова Мария Ивановна",
                    PatientGender = Gender.Female,
                    Birthday = DateTime.Now.AddYears(-28),
                    Address = "г. Санкт-Петербург, ул.Ленина, дом.25, кв.45",
                    BloodGroupOfPatient = BloodGroup.II,
                    RhFactorOfPatient = RhFactor.Positive,
                    Phone = "+79161234567"
                },
                new()
                {
                    IdPassport = "1998 654321",
                    Name = "Сидоров Андрей Владимирович",
                    PatientGender = Gender.Male,
                    Birthday = DateTime.Now.AddYears(-42),
                    Address = "г. Новосибирск, ул.Центральная, дом.10, кв.12",
                    BloodGroupOfPatient = BloodGroup.III,
                    RhFactorOfPatient = RhFactor.Negative,
                    Phone = "+79031234567"
                },
                new()
                {
                    IdPassport = "2010 987654",
                    Name = "Кузнецова Елена Сергеевна",
                    PatientGender = Gender.Female,
                    Birthday = DateTime.Now.AddYears(-31),
                    Address = "г. Екатеринбург, ул.Пушкина, дом.33, кв.78",
                    BloodGroupOfPatient = BloodGroup.IV,
                    RhFactorOfPatient = RhFactor.Positive,
                    Phone = "+79261234567"
                },
                new()
                {
                    IdPassport = "2005 456789",
                    Name = "Смирнов Алексей Петрович",
                    PatientGender = Gender.Male,
                    Birthday = DateTime.Now.AddYears(-25),
                    Address = "г. Казань, ул.Гагарина, дом.15, кв.23",
                    BloodGroupOfPatient = BloodGroup.I,
                    RhFactorOfPatient = RhFactor.Negative,
                    Phone = "+79501234567"
                },
                new()
                {
                    IdPassport = "2018 321654",
                    Name = "Васильева Ольга Дмитриевна",
                    PatientGender = Gender.Female,
                    Birthday = DateTime.Now.AddYears(-19),
                    Address = "г. Нижний Новгород, ул.Советская, дом.47, кв.56",
                    BloodGroupOfPatient = BloodGroup.II,
                    RhFactorOfPatient = RhFactor.Negative,
                    Phone = "+79991234567"
                },
                new()
                {
                    IdPassport = "1975 111111",
                    Name = "Николаев Виктор Иванович",
                    PatientGender = Gender.Male,
                    Birthday = DateTime.Now.AddYears(-50),
                    Address = "г. Москва, ул. Центральная, д. 10",
                    BloodGroupOfPatient = BloodGroup.II,
                    RhFactorOfPatient = RhFactor.Positive,
                    Phone = "+79111111111"
                },
                new()
                {
                    IdPassport = "1980 222222",
                    Name = "Орлова Светлана Петровна",
                    PatientGender = Gender.Female,
                    Birthday = DateTime.Now.AddYears(-43),
                    Address = "г. СПб, Невский пр., д. 25",
                    BloodGroupOfPatient = BloodGroup.III,
                    RhFactorOfPatient = RhFactor.Negative,
                    Phone = "+79222222222"
                }
            ];

        public List<Doctor> Doctors =>
            [
                new() {
                    IdPassport = "1223 456782",
                    Name = "Тимофеев Олег Борисович",
                    Birthday = DateTime.Now.AddYears(-40),
                    SpecializationOfDoctor = Specialization.Therapist,
                    WorkExperience = 10
                },
                new() {
                    IdPassport = "1234 567893",
                    Name = "Иванова Анна Сергеевна",
                    Birthday = DateTime.Now.AddYears(-35),
                    SpecializationOfDoctor = Specialization.Cardiologist,
                    WorkExperience = 8
                },
                new() {
                    IdPassport = "1345 678904",
                    Name = "Петров Дмитрий Викторович",
                    Birthday = DateTime.Now.AddYears(-45),
                    SpecializationOfDoctor = Specialization.Surgeon,
                    WorkExperience = 15
                },
                new() {
                    IdPassport = "1456 789015",
                    Name = "Сидорова Елена Михайловна",
                    Birthday = DateTime.Now.AddYears(-38),
                    SpecializationOfDoctor = Specialization.Pediatrician,
                    WorkExperience = 12
                },
                new() {
                    IdPassport = "1567 890126",
                    Name = "Козлов Артем Игоревич",
                    Birthday = DateTime.Now.AddYears(-42),
                    SpecializationOfDoctor = Specialization.Neurologist,
                    WorkExperience = 14
                },
                new() {
                    IdPassport = "1678 901237",
                    Name = "Федоров Сергей Васильевич",
                    Birthday = DateTime.Now.AddYears(-48),
                    SpecializationOfDoctor = Specialization.Dentist,
                    WorkExperience = 9  
                }
            ];

        public List<Visit> Visits =>
            [
                new() {
                    Patient = Patients[0],
                    Doctor = Doctors[0],
                    DateOfVisit = DateTime.Now.AddDays(-5),
                    TimeOfVisit = new TimeOnly(10, 30),
                    IdOfCabinet = 101,
                    IsAgain = false
                },
                new() {
                    Patient = Patients[1],
                    Doctor = Doctors[1],
                    DateOfVisit = DateTime.Now.AddDays(-3),
                    TimeOfVisit = new TimeOnly(14, 15),
                    IdOfCabinet = 205,
                    IsAgain = true
                },
                new() {
                    Patient = Patients[4],
                    Doctor = Doctors[2],
                    DateOfVisit = DateTime.Now.AddDays(-1),
                    TimeOfVisit = new TimeOnly(9, 0),
                    IdOfCabinet = 315,
                    IsAgain = false
                },
                new() {
                    Patient = Patients[5],
                    Doctor = Doctors[3],
                    DateOfVisit = DateTime.Now.AddDays(2),
                    TimeOfVisit = new TimeOnly(11, 45),
                    IdOfCabinet = 112,
                    IsAgain = false
                },
                new() {
                    Patient = Patients[2],
                    Doctor = Doctors[4],
                    DateOfVisit = DateTime.Now.AddDays(-7),
                    TimeOfVisit = new TimeOnly(16, 20),
                    IdOfCabinet = 308,
                    IsAgain = true
                },
                new() {
                    Patient = Patients[3],
                    Doctor = Doctors[0],
                    DateOfVisit = DateTime.Now.AddDays(1),
                    TimeOfVisit = new TimeOnly(13, 0),
                    IdOfCabinet = 101,
                    IsAgain = false
                },
                new() {
                    Patient = Patients[6],
                    Doctor = Doctors[0],
                    DateOfVisit = DateTime.Now.AddDays(-10),
                    TimeOfVisit = new TimeOnly(11, 0),
                    IdOfCabinet = 101,
                    IsAgain = false
                },
                new() {
                    Patient = Patients[6],
                    Doctor = Doctors[1],
                    DateOfVisit = DateTime.Now.AddDays(-8),
                    TimeOfVisit = new TimeOnly(15, 30),
                    IdOfCabinet = 205,
                    IsAgain = true
                },
                new() {
                    Patient = Patients[7],
                    Doctor = Doctors[2],
                    DateOfVisit = DateTime.Now.AddDays(-15),
                    TimeOfVisit = new TimeOnly(9, 45),
                    IdOfCabinet = 315,
                    IsAgain = false
                },
                new() {
                    Patient = Patients[7],
                    Doctor = Doctors[4],
                    DateOfVisit = DateTime.Now.AddDays(-12),
                    TimeOfVisit = new TimeOnly(14, 0),
                    IdOfCabinet = 308,
                    IsAgain = true
                },
                new() {
                    Patient = Patients[1],
                    Doctor = Doctors[0],
                    DateOfVisit = DateTime.Now.AddDays(-20),
                    TimeOfVisit = new TimeOnly(16, 0),
                    IdOfCabinet = 101,
                    IsAgain = true
                },
                new() {
                    Patient = Patients[1],
                    Doctor = Doctors[3],
                    DateOfVisit = DateTime.Now.AddDays(-2),
                    TimeOfVisit = new TimeOnly(10, 0),
                    IdOfCabinet = 101,
                    IsAgain = false
                }
            ];
    }
}