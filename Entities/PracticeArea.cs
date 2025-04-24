using HUKUK_PROJE.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class PracticeArea
{
    public int PracticeAreaID { get; set; }

    [Column(TypeName = "VarChar")]
    [StringLength(50)]
    public string? Icon { get; set; }

    [Column(TypeName = "VarChar")]
    [StringLength(150)]
    public string? Title { get; set; } // Eskiden başlık olarak kullanılıyordu ama artık LawTypes olacak

    [Column(TypeName = "VarChar")]
    [StringLength(150)]
    public string? Description { get; set; }

    [Column(TypeName = "VarChar")]
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    // Foreign Key
    public int? LawTypesID { get; set; }

    // Navigation Property
    public LawTypes? LawTypes { get; set; }

    public int? AreaID { get; set; }  // Foreign key
    public Area? Area { get; set; }  // Navigation property

}
