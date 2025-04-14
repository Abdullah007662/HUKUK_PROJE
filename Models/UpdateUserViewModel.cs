namespace HUKUK_PROJE.Models
{
    public class UpdateUserViewModel
    {
        public string? UserName { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
