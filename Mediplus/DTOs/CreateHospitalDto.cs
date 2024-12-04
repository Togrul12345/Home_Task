using Mediplus.Models;

namespace Mediplus.DTOs
{
    public class CreateHospitalDto
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public List<int> DoctorIds { get; set; }
   
     

    }
}
