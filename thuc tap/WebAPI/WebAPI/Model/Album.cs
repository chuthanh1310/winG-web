using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty; 
        public DateOnly? RealeaseDate { get; set; }
        public int Tracks { get; set; } = 0; // Sửa lỗi dấu '=' thành dấu '=>'
        public int? ProductID { get; set; }
        public Product Product { get; set; }
        public int? ArtistID { get; set; }
        public Artist Artist { get; set; }
        public List<Single> Singles { get; set; } = new List<Single>();
        
    }
}

