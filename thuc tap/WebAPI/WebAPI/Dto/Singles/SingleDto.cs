using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto.Singles
{
    public class SingleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ArtistName { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public string Genre {  get; set; }=string.Empty;
        public int? albumID { get; set; }
        public int? ProductID { get; set; }
        public int? ArtistID{get;set;}
    }
}