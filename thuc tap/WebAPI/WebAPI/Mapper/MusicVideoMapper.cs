using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto.MusicVideo;
using WebAPI.Model;

namespace WebAPI.Mapper
{
    public  static class MusicVideoMapper
    {
        public static MusicVideoDto ToMVDto(this MusicVideo musicVideo){
            return new MusicVideoDto{
                ID=musicVideo.Id,
                Title=musicVideo.Title,
                ReleaseDate=musicVideo.ReleaseDate,
                ArtistName=musicVideo.ArtistName,
                ProductID=musicVideo.ProductID
            };
        }
        public static MusicVideo ToAdd(this CreateMusicVideoDto videoDto,int ProductID){
            return new MusicVideo{
                Title=videoDto.Title,
                ReleaseDate=videoDto.ReleaseDate,
                ArtistName=videoDto.ArtistName,
                ProductID=ProductID
            };
        }
    }
}