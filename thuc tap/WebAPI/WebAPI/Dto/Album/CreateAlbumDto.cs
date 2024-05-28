namespace WebAPI.Dto.Album
{
    public class CreateAlbumDto
    {
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateOnly ReleaseDate {  get; set; }
        public int Tracks { get; set; }

    }
}
