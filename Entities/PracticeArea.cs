using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HUKUK_PROJE.Entities
{
    public class PracticeArea
    {
        public int PracticeAreaID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string? Icon { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(150)]
        public string? Title { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(150)]
        public string? Description { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string? ImageUrl { get; set; }
    }
}
