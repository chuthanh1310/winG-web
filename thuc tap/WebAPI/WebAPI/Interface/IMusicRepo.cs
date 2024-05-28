using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Interface
{
    public interface IMusicRepo
    {
        Task<MusicVideo> CreateAsync(MusicVideo musicVideo);
        Task<MusicVideo> GetIdByAsync(int id);
        Task<MusicVideo?> UpdateAsync(int id,MusicVideo musicVideo);
        Task<MusicVideo?>DeleteAsync(int id);
    }
}