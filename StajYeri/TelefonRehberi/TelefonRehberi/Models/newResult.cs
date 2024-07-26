using System.ComponentModel.DataAnnotations;

namespace TelefonRehberi.Models
{
    public class newResult
    {
        [Key]
        public int loginID { get; set; }
        public int loginPassword { get; set; }

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public int TelefonNo{ get; set;}

        public string Email { get; set; }
        
        public string imageUrl{ get; set; }



    }
}
