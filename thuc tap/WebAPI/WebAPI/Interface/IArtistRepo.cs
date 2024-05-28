using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto.Artist;
using WebAPI.Model;

namespace WebAPI.Interface
{
    public interface IArtistRepo
    {
        Task<Artist?> GetByIdAsync(int id);
        Task<Artist> CreateAsync(Artist artist);
        Task<Artist?>UpdateAsync(int id,CreateArtistDto createArtistDto);
        Task<Artist?>DeleteAsync(int id);
        Task<bool> HaveArtist(int id);
    }
}