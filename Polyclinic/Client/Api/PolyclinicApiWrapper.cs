namespace Client.Api;

public class PolyclinicApiWrapper(IConfiguration configuration)
{
    private readonly Polyclinic _client = new(
        configuration["OpenApi:ServerUrl"] ??
        throw new ArgumentNullException("OpenApi:ServerUrl not configured"),
        new HttpClient());


    public async Task<int> CreateDoctor(DoctorDto newDoctor) => await _client.DoctorPOSTAsync(newDoctor);
    public async Task<DoctorResponseDto> GetDoctor(int id) => await _client.DoctorGETAsync(id);
    public async Task<IList<DoctorResponseDto>> GetAllDoctors() =>  [.. await _client.DoctorAllAsync()];
    public async Task<DoctorDto> UpdateDoctor(int id, DoctorDto updatedDoctor) => await _client.DoctorPUTAsync(id, updatedDoctor);
    public async Task DeleteDoctor(int id) => await _client.DoctorDELETEAsync(id);


    public async Task<int> CreatePatient(PatientDto newPatient) => await _client.PatientPOSTAsync(newPatient);
    public async Task<PatientResponseDto> GetPatient(int id) => await _client.PatientGETAsync(id);
    public async Task<IList<PatientResponseDto>> GetAllPatients() => [.. await _client.PatientAllAsync()];
    public async Task<PatientDto> UpdatePatient(int id, PatientDto updatedPatient) => await _client.PatientPUTAsync(id, updatedPatient);
    public async Task DeletePatient(int id) => await _client.PatientDELETEAsync(id);


    public async Task<int> CreateVisit(VisitDto newVisit) => await _client.VisitPOSTAsync(newVisit);
    public async Task<VisitResponseDto> GetVisit(int id) => await _client.VisitGETAsync(id);
    public async Task<IList<VisitResponseDto>> GetAllVisits() => [.. await _client.VisitAllAsync()];
    public async Task<VisitDto> UpdateVisit(int id, VisitDto updatedVisit) => await _client.VisitPUTAsync(id, updatedVisit);
    public async Task DeleteVisit(int id) => await _client.VisitDELETEAsync(id);


    public async Task<IList<PatientResponseDto>> GetDoctorPatientsOrderedByName(int doctorId) => [.. await _client.PatientsAsync(doctorId)];
    public async Task<int> GetRepeatVisitsCountLastMonth() => await _client.RepeatCountAsync();
    public async Task<IList<PatientResponseDto>> GetPatientsOlderThan30WithMultipleDoctors() => [.. await _client.OlderThan30MultipleDoctorsAsync()];
    public async Task<IList<VisitResponseDto>> GetVisitsByCabinetCurrentMonth(string cabinet = "101-A") => [.. await _client.ByCabinetAsync(cabinet)];
    public async Task<IList<DoctorResponseDto>> GetExperiencedDoctors(int? minExperience = null) => [.. await _client.ExperiencedAsync(minExperience)];
}