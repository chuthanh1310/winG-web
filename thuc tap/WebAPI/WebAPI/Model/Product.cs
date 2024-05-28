namespace WebAPI.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public List<MusicVideo> musicVideos { get; set; }
        public List<Album> albums { get; set; }
        public ICollection<Comic> Comics { get; set; }
        public List<Single> singles { get; set; }
        public List<_3D> _3D { get; set; }
    }
}
