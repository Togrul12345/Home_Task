using Microsoft.AspNetCore.Mvc;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.Models;

namespace PurpleBuzzTask.Controllers
{
    public class ContactController : Controller
    {
        //AppDbContext _dbContext;
        //public ContactController(AppDbContext dbContext)
        //{
        //    _dbContext= dbContext;
        //}
        //public IActionResult Index()
        //{
        //    Contact contact = new Contact()
        //    {
        //        ContactType = "Texnik Dəstək",
        //        Name = "Toğrul Bağırov",
        //        PhoneNumber = "050-897-36-72",
                
        //    };
        //    Contact contact2 = new Contact()
        //    {
        //        ContactType = "Daşınma Dəstəyi",
        //        Name = "Fizarət Əmirov",
        //        PhoneNumber = "070-322-01-87",

        //    };
        //    Contact contact3 = new Contact()
        //    {
        //        ContactType = "Media Dəstəyi",
        //        Name = "Muxtar Hüseynov",
        //        PhoneNumber = "060-900-43-36",

        //    };
            
        //    //_dbContext.Contacts.AddRange(contact,contact2,contact3);
        //    //_dbContext.SaveChanges();
        //    IEnumerable<Contact> contacts= _dbContext.Contacts;
        //    return View(contacts);
        //}
    }
}
