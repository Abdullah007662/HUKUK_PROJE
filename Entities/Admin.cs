using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HUKUK_PROJE.Entities
{
    public class Admin
    {
        public int AdminID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string? UserName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string? Password { get; set; }
    }
}
