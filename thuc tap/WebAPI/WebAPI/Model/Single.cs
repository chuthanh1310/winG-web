namespace WebAPI.Model
{
    public class Single
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ArtistName { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public string Genre {  get; set; }=string.Empty;
        public int? albumID { get; set; }
        public Album Album { get; set; }
        public int? ProductID { get; set; }
        public Product Product { get; set; }
        public int? ArtistID{get;set;}
        public Artist Artist{get;set;}
    }
}
