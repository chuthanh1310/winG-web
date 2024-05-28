using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class AlbumRepo : IAlbumRepo
    {
        private readonly ApplicationDbContext _context;
        public AlbumRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Album> CreateAsync(Album album)
        {
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
            return album;
        }

       
        public async Task<Album?> DeleteAsync(int id)
        {
            var commentModel = await _context.Albums.FirstOrDefaultAsync(x => x.Id == id);
            if (commentModel == null)
            {
                return null;
            }
            _context.Albums.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        

        public async Task<Album> GetByIdAsync(int id)
        {
            return await _context.Albums.Include(c=>c.Singles).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<bool> HaveAlbum(int id)
        {
            return _context.Albums.AnyAsync(p => p.Id == id);
        }

        public async Task<Album?> UpdateAsync(int id, Album albumModel)
        {
            var existingAlbum = await _context.Albums.FindAsync(id);
            if (existingAlbum == null)
            {
                return null;
            }
            existingAlbum.Title=albumModel.Title;
            existingAlbum.Name=albumModel.Name;
            existingAlbum.RealeaseDate=albumModel.RealeaseDate;
            await _context.SaveChangesAsync();
            return existingAlbum;
        }
    }
}
