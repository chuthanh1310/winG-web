using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto.Artist;
using WebAPI.Model;

namespace WebAPI.Mapper
{
    public static class ArtistMapper
    {
        public static ArtistDto ToArtistDto(this Artist artist){
            return new ArtistDto{
                Id=artist.Id,
                Name=artist.Name,
                DateOfBirth=artist.DateOfBirth,
                StageName=artist.StageName,
                HomeTown=artist.HomeTown,
                Occupation=artist.Occupation,
                StyleOfMusic=artist.StyleOfMusic,
                TotalSong=artist.TotalSong,
                FilmParticipated=artist.FilmParticipated
            };
        }
        public static Artist ToAdd(this CreateArtistDto artistDto){
            return new Artist{
                Name=artistDto.Name,
                DateOfBirth=artistDto.DateOfBirth,
                StageName=artistDto.StageName,
                HomeTown=artistDto.HomeTown,
                Occupation=artistDto.Occupation,
                StyleOfMusic=artistDto.StyleOfMusic,
                TotalSong=artistDto.TotalSong,
                FilmParticipated=artistDto.FilmParticipated
            };
        }
    }
}