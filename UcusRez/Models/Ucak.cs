using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcusRez.Models
{
    [Table("Ucak")]
    public class Ucak
    {
        [Key]
        public int UcakID { get; set; }
        public int? UcakCapacity { get; set;}
    }
}
