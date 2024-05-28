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
    public class Repo3D : I3DRepo
    {
        private readonly ApplicationDbContext _context;
        public Repo3D(ApplicationDbContext context){
            _context=context;
        }
        public async Task<_3D> CreateAsync(_3D _3D)
        {
            await _context._3Ds.AddAsync(_3D);
            await _context.SaveChangesAsync();
            return _3D;
        }

        public async Task<_3D?> DeleteAsync(int id)
        {
            var Model3D=await _context._3Ds.FirstOrDefaultAsync(x=>x._3DID==id);
            if(Model3D==null)return null;
            _context._3Ds.Remove(Model3D);
            await _context.SaveChangesAsync();
            return Model3D;
        }

        public async Task<_3D> GetByIDAsync(int id)
        {
            return await _context._3Ds.FirstOrDefaultAsync(x=>x._3DID==id);
        }

        public async Task<_3D?> UpdateAsync(int id, _3D _3D)
        {
            var exist3D=await _context._3Ds.FindAsync(id);
            if(exist3D==null) return null;
            exist3D.Name=_3D.Name;
            await _context.SaveChangesAsync();
            return exist3D;
        }
    }
}