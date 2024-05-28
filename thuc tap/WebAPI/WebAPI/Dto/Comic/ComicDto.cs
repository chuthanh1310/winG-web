namespace WebAPI.Dto.Comic
{
    public class ComicDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;  
        public int? ProductID { get; set; }
    }
}
