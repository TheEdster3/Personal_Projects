using Library;
public interface IBook
{
    int ISBN { get; set; }
    string title { get; set; }
    Chapter[] chapters { get; set; }
    void ListAllBookPages();
    void ListAllChapterTitles();
}