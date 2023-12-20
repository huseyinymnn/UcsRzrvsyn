using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcusRez.Models
{
    [Table("Ucus")]
    public class Ucus
    {
        [Key]
        public int UcusID { get; set; }
        [ForeignKey ("Guzergah")]
        public int GuzergahID { get; set; }
        [ForeignKey("Ucak")]
        public int UcakID { get; set; }
        [Required]
        public DateTime UcusTime { get; set; }

        public Guzergah? Guzergah { get; set; }
        public Ucak? Ucak { get; set; }
    }
}
