using WebAPI.Dto.Chapter;
using WebAPI.Dto.Comic;
using WebAPI.Model;

namespace WebAPI.Mapper
{
    public static class ChapterMapper
    {
        public static ChapterDto ToChapterDto(this Chapter chapter)
        {
            return new ChapterDto
            {
                Id = chapter.Id,
                Title = chapter.Title,
                chapterNumber=chapter.chapterNumber,
                ReleaseDate=(DateOnly)chapter.ReleaseDate,
                ComicID=chapter.ComicID

            };
        }
        public static Chapter ToAdd(this CreateChapterDto createChapterDto, int chapterID)
        {
            return new Chapter
            {
                Title= createChapterDto.Title,
                chapterNumber = createChapterDto.chapterNumber,
                ReleaseDate=(DateOnly)createChapterDto.ReleaseDate,
                ComicID=chapterID
            };
        }
    }
}
