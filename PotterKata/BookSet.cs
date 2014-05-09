using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    using System;

    class BookSet
    {
        private BookSet(int setSize)
        {
            Books = new Book[setSize];
        }

        internal Book[] Books { get; private set; }
        
        private bool ContainsBook(Book book)
        {
            return Books.ElementAt(book.PositionInSet -1) != null;
        }

        internal static List<BookSet> OrderBooksIntoSets(IEnumerable<Book> books, int setSize = 5)
        {
            var sets = new List<BookSet>();
           
            foreach (var book in books)
            {
                var firstSetWithoutBook = FirstSetWithoutBook(sets, book);
                if (firstSetWithoutBook == null)
                {
                    var set = new BookSet(setSize);
                    set.Books[book.PositionInSet-1] = book;
                    sets.Add(set);
                }
                else
                {
                    firstSetWithoutBook.Books[book.PositionInSet-1] = book;
                }
            }
            return sets;
        }

        private static BookSet FirstSetWithoutBook(IEnumerable<BookSet> sets, Book book)
        {
            return sets.FirstOrDefault(s => !s.ContainsBook(book));
        }
    }
}