using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto.Album;
using WebAPI.Dto.Comic;
using WebAPI.Model;

namespace WebAPI.Dto.Product
{
    public class ProductDto
    {
        public int Id{get;set;}
        public string Name{get;set;}=string.Empty;
        public string Type{get;set;}=string.Empty;
        
        public List<ALbumDto> albums { get; set; }
        public List<ComicDto> Comics { get; set; }
       
    }
}