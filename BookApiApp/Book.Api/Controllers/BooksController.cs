using Book.Core.Entities;
using Book.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }
    }
}
