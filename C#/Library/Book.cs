using System;
using System.Collections.Generic;

namespace Library
{
    class Book : IBook
    {
        public int ISBN { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public DateTime datePublished { get; set; }
        public Chapter[] chapters { get; set; }

        public Book(int ISBN, string title)
        {
            this.ISBN = ISBN;
            this.title = title;
            chapters = new Chapter[10];
            for(int i = 0; i < chapters.Length; i++)
            {
                chapters[i] = new Chapter(i);
            }
        }

        public void ListAllBookPages()
        {
            for(int i = 0; i < chapters.Length; i++)
            {
                for(int j = 0; j < chapters[i].pages.Length; j++)
                {
                    Console.WriteLine(chapters[i].pages[j]);
                }
            }
        }

        public void ListAllChapterTitles()
        {
            for(int i = 0; i < chapters.Length; i++)
            {
                Console.WriteLine(chapters[i].title);
            }
        }

    }
}