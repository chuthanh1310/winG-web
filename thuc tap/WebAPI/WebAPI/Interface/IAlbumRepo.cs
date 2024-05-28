using WebAPI.Model;

namespace WebAPI.Interface
{
    public interface IAlbumRepo
    {
        
        Task<Album> CreateAsync(Album album);
        Task<Album> GetByIdAsync(int id);

        Task<Album?> UpdateAsync(int id, Album albumModel);
        Task<Album?> DeleteAsync(int id);
        Task<bool> HaveAlbum(int id);
   
    }
}
