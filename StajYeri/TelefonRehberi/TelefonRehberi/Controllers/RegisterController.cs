    using Microsoft.AspNetCore.Mvc;
    using TelefonRehberi.Data;
    using TelefonRehberi.Models;

namespace TelefonRehberi.Controllers
{

    public class RegisterController : Controller
    {


        private readonly DBContext _context;

        public RegisterController(DBContext context)
        {

            _context = context;
        }
        public IActionResult Index()
        {
            return View();
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

            public string imageUrl { get; set; }
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] newKayıt model)
        {
            if (ModelState.IsValid)
            {
                var değerBas = new newResult()
                {
                    Ad = model.firstname,
                    Soyad = model.lastname,
                    Adres = model.adress,
                    Email = model.email,
                    loginPassword = model.password,
                    TelefonNo = model.phone,
                    imageUrl= model.imageUrl,
                    };

                _context.newResults.Add(değerBas);
                _context.SaveChanges();
                return Ok(new { success = true });
            }
            else
            {
                return BadRequest("Hatalı Kayıt Girildi");
            }

        }
        [HttpPost]
 public async Task<IActionResult> Yukle(IFormFile dosya)
 {
     if (dosya != null && dosya.Length > 0)
     {
         // Dosya adını al
         var dosyaAdi = dosya.FileName;

         // Dosyayı geçici bir konuma kaydet
         var yuklemeYolu = Path.Combine(
             Directory.GetCurrentDirectory(), "wwwroot", "images",
             dosyaAdi);

         using (var stream = new FileStream(yuklemeYolu, FileMode.Create))
         {
             await dosya.CopyToAsync(stream);
         }

         // Başarıyla yüklendi mesajı veya başka bir işlem sonrası dönüş yap
         ViewBag.Message = "Dosya yüklendi: " + dosyaAdi;

         // JSON formatında başarı durumunu dön
         return Json(new { success = true, message = "Dosya yüklendi: " + dosyaAdi });
     }

     // Dosya yüklenmediyse hata durumu dönebilirsiniz
     return Json(new { success = false, message = "Dosya yüklenemedi." });
 }
     }
    }

