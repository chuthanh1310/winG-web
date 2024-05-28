using WebAPI.Model;

namespace WebAPI.Interface
{
    public interface IChapterRepo
    {
        Task<List<Chapter>> GetAllAsync();
        Task<Chapter> CreateAsync(Chapter chapter);
        Task<Chapter> GetByIdAsync(int id);

        Task<Chapter?> UpdateAsync(int id, Chapter chapter);
        Task<Chapter?> DeleteAsync(int id);
    }
}
