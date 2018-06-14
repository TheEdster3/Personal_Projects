using System;
using System.Collections.Generic;

namespace Library
{
    public class Chapter
    {
        public string title { get; set; }
        public int[] pages { get; set; }
        public List<int> bookmarks { get; set; }

        public Chapter(int multiplier)
        {
            bookmarks = new List<int>();

            string randomText = "abcdefghijklmnopqrstuvwxyz";
            string tempTitle = "";
            for(int i = 0; i < 6; i++)
            {
                tempTitle += randomText[new Random().Next(randomText.Length)];
            }
            this.title = tempTitle;

            pages = new int[10];
            for(int i = 0 + (10 * multiplier), j = 0; i < pages.Length + (10 * multiplier); i++, j++)
            {
                pages[j] = i;
            }
        } //This makes chapters/fake pages represented as numbers
        public void SaveBookmark(int page)
        {
            bookmarks.Add(page);
        }
        public void GetBookmarks()
        {
            for(int i = 0; i < bookmarks.Count; i++)
            {
                Console.WriteLine("Chapter:" + this.title + " Page: " + bookmarks[i]);
            }
        }
    }
}