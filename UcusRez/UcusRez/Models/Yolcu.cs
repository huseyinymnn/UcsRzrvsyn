using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcusRez.Models
{
    [Table("Yolcu")]
    public class Yolcu
    {
        [Key]
        public int YolcuID { get; set; }
        [Required(ErrorMessage = "İsim alanı boş bırakılamaz!")]
        public string? YolcuName { get; set; }
        [Required(ErrorMessage = "Soyisim alanı boş bırakılamaz!")]
        public string? YolcuSurname { get; set; }
        [Required(ErrorMessage = "TC NO alanı boş bırakılamaz!")]
        public int YolcuTC {  get; set; }
        [Required(ErrorMessage = "Doğum tarihi alanı boş bırakılamaz!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode =true)]
        public DateTime? YolcuDate { get; set; }
        [EnumDataType(typeof(Gender))]
        public string? YolcuGender { get; set; }
        [Required(ErrorMessage = "Mail alanı boş bırakılamaz!")]
        [DataType(DataType.EmailAddress)]
        public string? YolcuMail { get; set; }
        [Required(ErrorMessage = "Telefon numarası alanı boş bırakılamaz!"),RegularExpression(@"^([0-9]{10})&",ErrorMessage ="Lütfen geçerli bir telefon numarası giriniz!")]
        [StringLength(10)]
        public string? YolcuPhone { get; set; }

    }

    public enum Gender
    { 
        Erkek,
        Kadın,
        None
    }
}
