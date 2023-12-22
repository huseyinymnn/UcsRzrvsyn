﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcusRez.Models
{
    [Table("Kayit")]
    public class Kayit
    {
        [Key]
        public int KayitID { get; set; }
        [Required]
        public string? KayitName { get; set; }
        [Required]
        public string? KayitSurname { get; set; }
        [Required(ErrorMessage = "Mail alanı boş bırakılamaz!")]
        [DataType(DataType.EmailAddress)]
        public string? KayitMail { get; set; }
        [Required(ErrorMessage = "Sifre alanı boş bırakılamaz")]
        [DataType(DataType.Password)]
        public string? KayitPassword { get; set; }
        [Required(ErrorMessage = "Sifre alanı boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Compare("KayitPassword",ErrorMessage ="Sifreler eşleşmedi!")]
        public string? ConfKayitPassword { get; set; }
       
    }
}
