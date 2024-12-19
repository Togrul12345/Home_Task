using PurpleBuzzTask.Models;

namespace PurpleBuzzTask.DTOs.EmployeeDTOs
{
    public class CreateEmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IFormFile ImgUrl { get; set; }
        public string Profession { get; set; }
        public ICollection<int> WorkIds { get; set; }
    }
}
