using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories;

public interface IPatientRepository
{
    public int Create(Patient entity);

    public List<Patient> Read();

    public Patient? Read(string passport);

    public Patient? Read(int id);

    public Patient? Update(int id, Patient entity);

    public bool Delete(int id);
}
