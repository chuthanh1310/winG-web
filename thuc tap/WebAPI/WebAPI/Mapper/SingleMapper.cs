using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto.Singles;
using WebAPI.Model;

namespace WebAPI.Mapper
{
    public static class SingleMapper
    {
        public static SingleDto ToSingleDto(this Model.Single single){
            return new SingleDto{
                Id= single.Id,
                Title=single.Title,
                ArtistName=single.ArtistName,
                ReleaseDate=single.ReleaseDate,
                Genre=single.Genre,
                albumID=single.albumID,
                ProductID=single.ProductID,
                ArtistID=single.ArtistID
            };
        }
        public static Model.Single ToAddFromArtist(this CreateSingleDto single,int ArtistID){
            return new Model.Single{
                Title=single.Title,
                ArtistName=single.ArtistName,
                ReleaseDate=single.ReleaseDate,
                Genre=single.Genre,
                ArtistID=ArtistID
            };
        }
        public static Model.Single ToAddFromProduct(this CreateSingleDto single,int ProductID){
            return new Model.Single{
                Title=single.Title,
                ArtistName=single.ArtistName,
                ReleaseDate=single.ReleaseDate,
                Genre=single.Genre,
                ProductID=ProductID
            };
        }
        public static Model.Single ToAddFromAlbum(this CreateSingleDto single,int AlbumID){
            return new Model.Single{
                Title=single.Title,
                ArtistName=single.ArtistName,
                ReleaseDate=single.ReleaseDate,
                Genre=single.Genre,
                albumID=AlbumID
            };
        }
        public static Model.Single ToUpdate(this CreateSingleDto singleDto,int ProductID){
            return new Model.Single
            {
                Title=singleDto.Title,
                ArtistName=singleDto.ArtistName,
                ReleaseDate=singleDto.ReleaseDate,
                Genre=singleDto.Genre
            };
        }
    }
}