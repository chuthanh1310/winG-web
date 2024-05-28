using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto.Singles
{
    public class CreateSingleDto
    {
        public string Title { get; set; }
        public string? ArtistName { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public string Genre {  get; set; }=string.Empty;

    }
}