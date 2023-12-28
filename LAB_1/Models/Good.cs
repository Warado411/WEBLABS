namespace WEB.Models
{
    public class Good
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}
