using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HUKUK_PROJE.Entities
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string? NameSurname { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string? ImageUrl { get; set; }
    }
}
