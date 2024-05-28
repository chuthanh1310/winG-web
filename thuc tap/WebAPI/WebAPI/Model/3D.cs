using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    [Table("3D")]
    public class _3D
    {
        
        public int _3DID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? ProductID { get; set; }
        public Product Product { get; set; }
    }
}
