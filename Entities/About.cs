using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HUKUK_PROJE.Entities
{
    public class About
    {
        public int AboutID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string? Title { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(200)]
        public string? ImageUrl { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(200)]
        public string? SignatureUrl { get; set; }
    }
}
