using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HUKUK_PROJE.Entities
{
    public class Blog
    {
        public int BlogID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(150)]
        public string? Title { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(150)]
        public string? SmallTitle { get; set; }

        [Column(TypeName = "VarChar")]
        public string? Description { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string? ImageUrl { get; set; }
    }
}
