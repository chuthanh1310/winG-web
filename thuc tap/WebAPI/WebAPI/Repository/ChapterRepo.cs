using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class ChapterRepo : IChapterRepo
    {
        private readonly ApplicationDbContext _context;
        public ChapterRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Chapter> CreateAsync(Chapter chapter)
        {
            await _context.Chapters.AddAsync(chapter);
            await _context.SaveChangesAsync();
            return chapter;
        }

        public async Task<Chapter?> DeleteAsync(int id)
        {
            var commentModel = await _context.Chapters.FirstOrDefaultAsync(x => x.Id == id);
            if (commentModel == null)
            {
                return null;
            }
            _context.Chapters.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Chapter>> GetAllAsync()
        {
            return await _context.Chapters.ToListAsync();
        }

        public async Task<Chapter> GetByIdAsync(int id)
        {
            return await _context.Chapters.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Chapter?> UpdateAsync(int id, Chapter chapter)
        {
            var existingChapter = await _context.Chapters.FindAsync(id);
            if (existingChapter == null)
            {
                return null;
            }
            existingChapter.Title = chapter.Title;
            existingChapter.chapterNumber = chapter.chapterNumber;
            existingChapter.ReleaseDate= chapter.ReleaseDate;
            await _context.SaveChangesAsync();
            return existingChapter;
        }
    }
}
