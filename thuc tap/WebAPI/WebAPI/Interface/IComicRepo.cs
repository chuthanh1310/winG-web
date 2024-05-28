using WebAPI.Model;

namespace WebAPI.Interface
{
    public interface IComicRepo
    {
        Task<List<Comic>> GetAllAsync();
        Task<Comic> CreateAsync(Comic comic);
        Task<Comic> GetByIdAsync(int id);

        Task<Comic?> UpdateAsync(int id, Comic comicModel);
        Task<Comic?> DeleteAsync(int id);
        Task<bool> HaveComic(int id);
        
    }
}
