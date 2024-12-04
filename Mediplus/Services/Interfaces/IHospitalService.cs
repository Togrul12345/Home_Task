using Mediplus.Models;

namespace Mediplus.Services.Interfaces
{
    public interface IHospitalService
    {
        void CreateHospital(Hospital hospital);
        Task<Hospital> GetHospitalById(int id);
        void RemoveHospital(Hospital hospital,int id);
        Task<List<Hospital>> GetAllHospitals();
    }
}
