using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Model;

namespace WebAPI.Repository

{
    public class MusicRepo : IMusicRepo
    {
        private readonly ApplicationDbContext _context;
        public MusicRepo(ApplicationDbContext context){
            _context=context;
        }
        public async Task<MusicVideo> CreateAsync(MusicVideo musicVideo)
        {
            await _context.MusicVideos.AddAsync(musicVideo);
            await _context.SaveChangesAsync();
            return musicVideo;
        }

        public async Task<MusicVideo?> DeleteAsync(int id)
        {
            var musicVideo=await _context.MusicVideos.FirstOrDefaultAsync(x=>x.Id==id);
            if(musicVideo==null) return null;
            _context.MusicVideos.Remove(musicVideo);
            await _context.SaveChangesAsync();
            return musicVideo;
        }

        public async Task<MusicVideo> GetIdByAsync(int id)
        {
            return await _context.MusicVideos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<MusicVideo?> UpdateAsync(int id, MusicVideo musicVideo)
        {
            var existingMV=await _context.MusicVideos.FindAsync(id);
            if(existingMV==null){
                return null;
            }
            existingMV.Title=musicVideo.Title;
            existingMV.ArtistName=musicVideo.ArtistName;
            existingMV.ReleaseDate=musicVideo.ReleaseDate;
            await _context.SaveChangesAsync();
            return existingMV;
        }
    }
}