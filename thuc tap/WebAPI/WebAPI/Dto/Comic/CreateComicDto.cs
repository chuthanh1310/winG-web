namespace WebAPI.Dto.Comic
{
    public class CreateComicDto
    {
        public string Title { get; set; }=string.Empty;
        public string Name {  get; set; }=string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;

    }
}
