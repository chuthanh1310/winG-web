using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.Artist;
using WebAPI.Interface;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class ArtistRepo : IArtistRepo
    {
        private readonly ApplicationDbContext _context;
        public ArtistRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Artist> CreateAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist?> DeleteAsync(int id)
        {
            var product=await _context.Artists.FirstOrDefaultAsync(x=>x.Id==id);
            if (product==null)
            {
                return null;
            }
            _context.Artists.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Artist?> GetByIdAsync(int id)
        {
            return await _context.Artists.Include(c=>c.Albums).Include(c=>c.Singles).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public Task<bool> HaveArtist(int id)
        {
            return _context.Artists.AnyAsync(x=>x.Id==id);
        }

        public async Task<Artist?> UpdateAsync(int id, CreateArtistDto createArtistDto)
        {
            var existingProduct=await _context.Artists.FirstOrDefaultAsync(x=>x.Id==id);
            if (existingProduct==null)
            {
                return null;
            }
            existingProduct.Name=createArtistDto.Name;
            existingProduct.DateOfBirth=createArtistDto.DateOfBirth;
            existingProduct.StageName=createArtistDto.StageName;
            existingProduct.HomeTown=createArtistDto.HomeTown;
            existingProduct.Occupation=createArtistDto.Occupation;
            existingProduct.StyleOfMusic=createArtistDto.StyleOfMusic;
            existingProduct.TotalSong=createArtistDto.TotalSong;
            existingProduct.FilmParticipated=createArtistDto.FilmParticipated;
            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}