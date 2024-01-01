using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcusRez.Models
{
    [Table("Bilet")]
    public class Bilet
    {
        [Key]
        public int BiletId { get; set; }

        public string? YolcuAd { get; set; }
       
        public string? YolcuSoyad { get; set; }
        
        public string? YolcuCinsiyet { get; set; }
        
        public string? YolcuPasaport { get; set; }
        
        public string? YolcuDogumTarihi { get; set; }
        
        public string? YolcuMail { get; set; }
        
        public string? KalkisSehri { get; set; }
        
        public string? VarisSehri { get; set; }
        
        public string? KalkisTarihi { get; set; }

        public int? KoltukNumarasi { get; set; }
        
    }
}
