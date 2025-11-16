using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories;
public interface IDoctorRepository
{
    public int Create(Doctor entity);

    public List<Doctor> Read();

    public Doctor? Read(string passport);

    public Doctor? Read(int id);

    public Doctor? Update(int id, Doctor entity);

    public bool Delete(int id);
}
