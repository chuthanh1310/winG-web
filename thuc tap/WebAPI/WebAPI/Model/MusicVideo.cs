namespace WebAPI.Model
{
    public class MusicVideo
    {
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        
        public DateOnly? ReleaseDate { get; set; }
        public string? ArtistName { get; set; }
        public int ProductID {  get; set; }
        public Product Product { get; set; }
    }
}
