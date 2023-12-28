namespace WEB.Models
{
    public class Section
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<Good> Goods { get; set; }
    }
}
