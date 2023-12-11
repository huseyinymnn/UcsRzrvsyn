using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcusRez.Models
{
    [Table("Bilet")]
    public class Bilet
    {
        [Key]
        public int Id { get; set; } 
        public int KoltukNumarasi { get; set; }
        [ForeignKey("Yolcu")]
        public int YolcuID {  get; set; }
        [ForeignKey("Ucus")]
        public int UcusID { get; set; }
        
        public Ucus? Ucus { get; set; }
        public Yolcu? Yolcu { get; set; }   
    }
}
