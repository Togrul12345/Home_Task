using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.Models;

namespace PurpleBuzzTask.ViewComponents
{
    public class RecentWorksViewComponent:ViewComponent
    {
        public readonly AppDbContext _appDbContext;
        public RecentWorksViewComponent(AppDbContext dbContext)
        {
            _appDbContext = dbContext;   
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
          IEnumerable<Work> works=await  _appDbContext.Works.OrderByDescending(a => a.Id).Take(3).ToListAsync();
            return View(works);
        }
    }
}
