using System;
using System.Collections.Generic;

namespace Library
{
    class Library
    {
        public Dictionary<int, IBook> books { get; set; }

        public Library()
        {
            this.books = new Dictionary<int, IBook>();
        }
        public void AddBook(IBook book)
        {
            books.Add(book.ISBN, book);
        }

        public IBook GetSpecificBook(int ISBN)
        {
            books.TryGetValue(ISBN, out IBook book);
            return book;
        }
    }
}