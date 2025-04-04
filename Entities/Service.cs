using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HUKUK_PROJE.Entities
{
    public class Service
    {
        public int ServiceID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(150)]
        public string? Title { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(200)]
        public string? ImageUrl { get; set; }

    }
}
