using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto.MusicVideo
{
    public class CreateMusicVideoDto
    {
        public string Title { get; set; }=string.Empty;
        
        public DateOnly? ReleaseDate { get; set; }
        public string? ArtistName { get; set; }
    }
}