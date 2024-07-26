using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.Data;

namespace TelefonRehberi.Controllers
{
    public class DeletePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly DBContext _context;

        public DeletePageController(DBContext context)
        {
            _context = context;
        }

        public class newKayıt
        {
        
            public string email { get; set; }
          
        }
        [HttpPost]
        public IActionResult DeleteRecord([FromBody] newKayıt model)
        {
            if (ModelState.IsValid)
            {
                // Silinecek kaydı bulun
                var recordToDelete = _context.newResults.FirstOrDefault(r => r.Email == model.email);

                if (recordToDelete != null)
                {
                    // Kaydı veritabanından sil
                    _context.newResults.Remove(recordToDelete);
                    _context.SaveChanges();

                    return Ok(new { success = true });
                }
                else
                {
                    return NotFound("Silinecek kayıt bulunamadı");
                }
            }
            else
            {
                return BadRequest("Hatalı kayıt bilgileri");
            }
        }

    }
}
