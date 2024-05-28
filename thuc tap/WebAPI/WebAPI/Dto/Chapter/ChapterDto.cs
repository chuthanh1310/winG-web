namespace WebAPI.Dto.Chapter
{
    public class ChapterDto
    {
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public int chapterNumber {  get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int? ComicID { get; set; }

    }
}
