using Microsoft.AspNetCore.Identity;

namespace HUKUK_PROJE.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public string? Name { get; set; }
        public int ConfirmCode { get; set; }

    }
}
