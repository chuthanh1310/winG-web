using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto.MusicVideo
{
    public class MusicVideoDto
    {
        public int ID{get;set;}
        public string Title { get; set; }=string.Empty;
        
        public DateOnly? ReleaseDate { get; set; }
        public string? ArtistName { get; set; }
        public int? ProductID { get; set; }
    }
}