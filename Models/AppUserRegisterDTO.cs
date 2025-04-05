using System.ComponentModel.DataAnnotations;

namespace HUKUK_PROJE.Models
{
    public class AppUserRegisterDTO
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        public string? KullanıcıAdı { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [DataType(DataType.Password)]
        public string? Şifre { get; set; }

        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir email giriniz")]
        public string? Email { get; set; }
    }
}
