using Domain;
using Domain.Seeder;

namespace Infrastructure.Db.Seeder;

/// <summary>
/// Class with data about entitys for DataBase
/// </summary>
public class DbSeeder
{
    /// <summary>
    /// List of all patients
    /// </summary>
    public List<Patient> Patients => new DataSeeder().Patients;

    /// <summary>
    /// List of all doctors
    /// </summary>
    public List<Doctor> Doctors => new DataSeeder().Doctors;

    /// <summary>
    /// List of all appointments
    /// </summary>
    public List<Visit> Visits => new DataSeeder().Visits;

}
