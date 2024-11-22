using PurpleBuzzTask.Models;

namespace PurpleBuzzTask.ViewModel
{
    public class DisplayData
    {
        public IEnumerable<TeamMate> Teammates {  get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
