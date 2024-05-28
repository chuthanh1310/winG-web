using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto.Artist
{
    public class CreateArtistDto
    {
        public string Name { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string StageName {  get; set; } = string.Empty;
        public string HomeTown { get; set; } = string.Empty;
        public string Occupation {  get; set; } = string.Empty;
        public string StyleOfMusic { get; set; } = string.Empty;
        public int? TotalSong { get; set; } = 0;
        public int? FilmParticipated { get; set; } = 0;
    }
}