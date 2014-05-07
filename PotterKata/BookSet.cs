using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    class BookSet
    {
        private BookSet()
        {
            Books = new List<Book>();
        }

        internal List<Book> Books { get; private set; }

        internal static List<BookSet> OrderBooksIntoSets(IEnumerable<Book> books)
        {
            var sets = new List<BookSet>();
           
            foreach (var book in books)
            {
                var firstSetWithoutBook = sets.FirstOrDefault(s => !s.Books.Contains(book));
                if (firstSetWithoutBook == null)
                {
                    var set = new BookSet();
                    set.Books.Add(book);
                    sets.Add(set);
                }
                else
                {
                    firstSetWithoutBook.Books.Add(book);
                }
            }
            return sets;
        }
    }
}