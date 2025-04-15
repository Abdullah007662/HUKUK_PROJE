namespace HUKUK_PROJE.Entities
{
    public class Area
    {
        public int AreaID { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        // Foreign Key
        public int LawTypesID { get; set; }

        // Navigation Property
        public LawTypes? LawTypes { get; set; }
    }
}
