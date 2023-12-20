using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcusRez.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required(ErrorMessage ="Mail alanı boş bırakılamaz!")]
        [DataType(DataType.EmailAddress)]
        public string? AdminMail { get; set; }
        [Required(ErrorMessage ="Sifre alanı boş bırakılamaz")]
        [DataType(DataType.Password)]
        public string? AdminPassword { get; set; }
    }
}
