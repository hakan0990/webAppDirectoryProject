using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelefonRehberi.Data;

namespace TelefonRehberi.Controllers
{
        
    public class LoginPageController : Controller
    {
		private readonly DBContext _context;

		public LoginPageController(DBContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
		public async Task<IActionResult>GetAll()
		{
			var results = await _context.newResults.ToListAsync();

			return Json(new { data = results.ToList() });
		}
		



    }
}
