namespace WebAPI.Dto.Album
{
    public class ALbumDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
        public int Tracks { get; set; }
        public int? ProductID { get; set; }
        public int? ArtistID{get;set;}
    }
}
