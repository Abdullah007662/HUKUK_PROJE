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
        public string? Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası gereklidir.")]
        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Randevu tarihi gereklidir.")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Randevu saati gereklidir.")]
        [DataType(DataType.Time)]
        public TimeSpan AppointmentTime { get; set; }
        [Required(ErrorMessage = "Kısaca Olayı Anlatınız.!")]
        [StringLength(500)]
        public string? Message { get; set; }
        public LawTypes? LawTypes { get; set; }


    }
}
