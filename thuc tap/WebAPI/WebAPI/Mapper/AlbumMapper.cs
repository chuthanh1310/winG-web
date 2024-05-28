using WebAPI.Dto.Album;
using WebAPI.Model;

namespace WebAPI.Mapper
{
    public static class AlbumMapper
    {
        public static ALbumDto ToAlbumDto(this Album album)
        {
            return new ALbumDto
            {
                Id = album.Id,
                Title = album.Title,
                Name = album.Name,
                ReleaseDate=(DateOnly)album.RealeaseDate,
                Tracks = album.Tracks,
                ProductID = album.ProductID,
                ArtistID=album.ArtistID
            };
        }
        
        public static Album ToAddFromProduct(this CreateAlbumDto createAlbumDto,int ProductID) {
            return new Album { 
            Title=createAlbumDto.Title,
            Name=createAlbumDto.Name,
            RealeaseDate=createAlbumDto.ReleaseDate,
            Tracks=createAlbumDto.Tracks,
            ProductID = ProductID,
            };
        }
        public static Album ToAddFromArtist(this CreateAlbumDto createAlbumDto,int ArtistID){
            return new Album{
                Title=createAlbumDto.Title,
                Name=createAlbumDto.Name,
                RealeaseDate=createAlbumDto.ReleaseDate,
                Tracks=createAlbumDto.Tracks,
                ArtistID=ArtistID
            };
        }
        public static Album ToUpdate(this CreateAlbumDto albumDto,int ProductID){
            return new Album{
                Title=albumDto.Title,
                Name=albumDto.Name,
                RealeaseDate=albumDto.ReleaseDate,
                Tracks=albumDto.Tracks,
            };
        }
    }
}
