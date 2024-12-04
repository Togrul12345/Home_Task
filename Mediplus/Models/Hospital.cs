namespace Mediplus.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public IEnumerable<DoctorHospital> DoctorHospitals { get; set; }
    }
}
