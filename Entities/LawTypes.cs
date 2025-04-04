using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HUKUK_PROJE.Entities
{
    public class LawTypes
    {
        public int LawTypesID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string? Type { get; set; }
    }
}
