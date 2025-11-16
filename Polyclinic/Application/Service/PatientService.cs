using Application.DTO;
using Domain;
using Domain.Repositories;

namespace Application.Service;
public class PatientService(IPatientRepository repository)
{
    private static Patient MapDto(PatientDto entity)
    {
        return new Patient
        {
            Id = 0,
            Passport = entity.Passport,
            Name = entity.Name,
            Gender = entity.Gender,
            Birthday = entity.Birthday,
            Address = entity.Address,
            BloodGroup = entity.BloodGroup,
            RhFactor = entity.RhFactor,
            Phone = entity.Phone,
        };

    }
    public int CreatePatinet(PatientDto entity)
    {
        return repository.Create(MapDto(entity));
    }

}
