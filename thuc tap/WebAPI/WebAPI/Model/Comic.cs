namespace WebAPI.Model
{
    public class Comic
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateOnly? ReleaseDate { get; set; }
        public string Genre {  get; set; } = string.Empty;
        public int ProductID {  get; set; }
        public Product? Product { get; set; }
        public List<Chapter> Chapters { get; set; }=new List<Chapter>();
        
    }
}
