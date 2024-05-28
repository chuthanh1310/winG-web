using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class ComicRepo : IComicRepo
    {
        private readonly ApplicationDbContext _context;
        public ComicRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comic> CreateAsync(Comic comic)
        {
            await _context.Comics.AddAsync(comic);
            await _context.SaveChangesAsync();
            return comic;
        }

        public async Task<Comic?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comics.FirstOrDefaultAsync(x => x.Id == id);
            if (commentModel == null)
            {
                return null;
            }
            _context.Comics.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comic>> GetAllAsync()
        {
            return await _context.Comics.ToListAsync();
        }

        public async Task<Comic> GetByIdAsync(int id)
        {
            return await _context.Comics.Include(c=>c.Chapters).FirstOrDefaultAsync(c=>c.Id == id);
        }

        public Task<bool> HaveComic(int id)
        {
            return _context.Comics.AnyAsync(p => p.Id == id);
        }

        public async Task<Comic?> UpdateAsync(int id, Comic comicModel)
        {
            var existingComic = await _context.Comics.FindAsync(id);
            if (existingComic == null)
            {
                return null;
            }
            existingComic.Name= comicModel.Name;
            existingComic.Author= comicModel.Author;
            existingComic.ReleaseDate= comicModel.ReleaseDate;
            existingComic.Genre= comicModel.Genre;
            await _context.SaveChangesAsync();
            return existingComic;
        }

        
    }
}
