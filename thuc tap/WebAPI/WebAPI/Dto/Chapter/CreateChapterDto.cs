namespace WebAPI.Dto.Chapter
{
    public class CreateChapterDto
    {
        public string Title { get; set; } = string.Empty;
        public int chapterNumber { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
