using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace HUKUK_PROJE.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(25)]
        public string? NameSurname { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string? Department { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(200)]
        public string? InstagramUrl { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(150)]
        public string? TwitterUrl { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(150)]
        public string? FacebookUrl { get; set; }
    }
}
