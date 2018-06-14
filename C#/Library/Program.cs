using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Library myLibrary = new Library();

            Book myBook = new Book(123, "Brave New World");
            myLibrary.AddBook(myBook);

            IBook tempBook = myLibrary.GetSpecificBook(myBook.ISBN);
            myLibrary.GetSpecificBook(myBook.ISBN).ListAllChapterTitles();
            myLibrary.GetSpecificBook(myBook.ISBN).chapters[2].SaveBookmark(tempBook.chapters[2].pages[5]);
            tempBook.chapters[2].GetBookmarks();

        }
    }
}
