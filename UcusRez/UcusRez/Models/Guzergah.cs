using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcusRez.Models
{
    [Table("Guzergah")]
    public class Guzergah
    {
        [Key]
        public int GuzergahID { get; set; } 
        public string? KalkisSehri { get; set;}
        public string? VarisSehri { get; set; }

    }
}
