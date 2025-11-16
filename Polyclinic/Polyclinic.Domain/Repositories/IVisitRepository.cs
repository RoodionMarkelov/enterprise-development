using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories;
public interface IVisitRepository
{
    public int Create(Visit entity);

    public List<Visit> Read();

    public Visit? Read(int id);

    public Visit? Update(int id, Visit entity);

    public bool Delete(int id);
}
