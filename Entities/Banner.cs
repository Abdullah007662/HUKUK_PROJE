using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HUKUK_PROJE.Entities
{
    public class Banner
    {
        public int BannerID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(150)]
        public string? Title { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        public string? ImageUrl { get; set; }
    }
}
