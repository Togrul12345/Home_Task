namespace Mediplus.Models
{
    public class DoctorHospital
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int HospitalIds { get; set; }
        public Hospital Hospital { get; set; }
    }
}
