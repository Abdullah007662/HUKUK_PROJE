using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HUKUK_PROJE.Entities
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Required(ErrorMessage = "Ad soyad gereklidir.")]
        [StringLength(30)]
        public string? NameSurname { get; set; }

        [Required(ErrorMessage = "Email gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        [StringLength(150)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası gereklidir.")]
        [StringLength(11)]
        public string? PhoneNumber { get; set; }

        [StringLength(500)]
        public string? Message { get; set; }
        public LawTypes? LawTypes { get; set; }


    }
}
