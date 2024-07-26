using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.Data;
using TelefonRehberi.Models;

namespace TelefonRehberi.Controllers
{
    public class HomePageController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        private readonly DBContext _context;

        public HomePageController(DBContext context)
        {
            _context = context;
        }

        public class İşlem1
        {
            public int loginName { get; set; }
            public int password { get; set; }
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] İşlem1 model)
        {
            if (ModelState.IsValid)
            {
                int loginName = model.loginName; // Kullanıcı adını modelden al
                int  password = model.password; // Şifreyi modelden al

                // Veritabanından kullanıcı bilgilerini kontrol etmek için gerekli işlemleri yapalım
                var user = _context.newResults.FirstOrDefault(u => u.loginID == loginName);

                // Kullanıcıyı loginName'e göre sorgula
                if (user != null && user.loginPassword == password)
                {
                    return Ok("Giriş başarılı!");
                }

                // ModelState geçersizse veya kullanıcı bulunamazsa hata döndürün
                return BadRequest("Geçersiz giriş bilgileri.");
            }

            // ModelState geçersizse hata döndürün
            return BadRequest("Geçersiz model.");
        }
    }
}

