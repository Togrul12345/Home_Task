using PurpleBuzzTask.Models;

namespace PurpleBuzzTask.ViewModel
{
    public class DisplayData
    {
        public IEnumerable<Work> Works {  get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}
