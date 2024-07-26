using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.Data;
using TelefonRehberi.Models;

namespace TelefonRehberi.Controllers
{
    public class OrganisePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly DBContext _context;

        public OrganisePageController(DBContext context)
        {
            _context = context;
        }

        public class newKayıt
        {
            public int username { get; set; }
            public int password { get; set; }
            public string email { get; set; }
            public int phone { get; set; }
            public string adress { get; set; }
            public string firstname { get; set; }

            public string lastname { get; set; }

        }
        [HttpPost]
        public IActionResult Authenticate([FromBody] newKayıt model)
        {
            if (ModelState.IsValid)
            {
                // Önce güncellenecek kaydı bulun
                var existingRecord = _context.newResults.FirstOrDefault(r => r.TelefonNo == model.phone);

                if (existingRecord != null)
                {
                    // Varolan kaydı güncelleyin
                    existingRecord.Ad = model.firstname;
                    existingRecord.Soyad = model.lastname;
                    existingRecord.Adres = model.adress;
                    existingRecord.Email = model.email;
                    existingRecord.loginPassword = model.password;
                    existingRecord.TelefonNo = model.phone;

                    // Değişikliği veritabanına kaydedin
                    _context.SaveChanges();

                    return Ok(new { success = true });
                }
                else
                {
                    return NotFound("Güncellenecek kayıt bulunamadı");
                }
            }
            else
            {
                return BadRequest("Hatalı Kayıt Girildi");
            }
        }
    }

}