using WebAPI.Dto.Comic;
using WebAPI.Model;

namespace WebAPI.Mapper
{
    public static class ComicMapper
    {
        public static ComicDto ToComicDto (this Comic comic){
            return new ComicDto
            {
                Id = comic.Id,
                Name = comic.Name,
                Author = comic.Author,
                ReleaseDate = (DateOnly)comic.ReleaseDate,
                Genre=comic.Genre,
                ProductID=comic.ProductID,

            };
        }
        public static Comic ToAdd(this CreateComicDto createComicDto,int productID)
        {
            return new Comic
            {
                Name = createComicDto.Name,
                Author=createComicDto.Author,
                ReleaseDate=createComicDto.ReleaseDate,
                Genre=createComicDto.Genre,
                ProductID=productID,
            };
        }
    }
}
