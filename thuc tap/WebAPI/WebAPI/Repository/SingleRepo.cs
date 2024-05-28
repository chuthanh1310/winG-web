using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interface;

namespace WebAPI.Repository
{
    public class SingleRepo : ISingleRepo
    {
        private readonly ApplicationDbContext _context;
        public SingleRepo (ApplicationDbContext context){
            _context=context;
        }
        public async Task<Model.Single> CreateAsync(Model.Single Single)
        {
            await _context.Singles.AddAsync(Single);
            await _context.SaveChangesAsync();
            return Single;
        }

        public async Task<Model.Single?> DeleteAsync(int id)
        {
            var Single=await _context.Singles.FirstOrDefaultAsync(x=>x.Id==id);
            if(Single==null)return null;
            _context.Singles.Remove(Single);
            await _context.SaveChangesAsync();
            return Single;
        }

        public async Task<Model.Single> GetByIDAsync(int id)
        {
            return await _context.Singles.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Model.Single?> UpdateAsync(int id, Model.Single Single)
        {
            var SingleExist=await _context.Singles.FindAsync(id);
            if(SingleExist==null) return null;
            SingleExist.Title=Single.Title;
            SingleExist.ArtistName=Single.ArtistName;
            SingleExist.ReleaseDate=Single.ReleaseDate;
            SingleExist.Genre=Single.Genre;
            await _context.SaveChangesAsync();
            return SingleExist;
        }
    }
}