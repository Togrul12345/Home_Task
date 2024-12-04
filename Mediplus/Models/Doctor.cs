namespace Mediplus.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public IEnumerable<DoctorHospital> DoctorHospitals { get; set; }
    }
}
