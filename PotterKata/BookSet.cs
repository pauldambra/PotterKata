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
            return Books.Length >= book.PositionInSet 
                && Books.ElementAt(book.PositionInSet -1) != null;
        }

        internal void AddBook(Book book)
        {
            if (ContainsBook(book))
            {
                throw new ArgumentException("This set already contains this book.");
            }
            Books[book.PositionInSet - 1] = book;
        }

        internal static List<BookSet> OrderBooksIntoSets(List<Book> books, int setSize = 5)
        {
            if (!books.Any())
            {
                return new List<BookSet>();
            }

            var positionFrequency = books.GroupBy(b => b.PositionInSet)
                .Select(grp => new { grp.Key, Value = grp.ToList() })
                .ToDictionary(grp => grp.Key, grp => grp.Value );

            var highestFrequency = positionFrequency.Values.Max(v=>v.Count);

            var sets = new BookSet[highestFrequency];
            foreach (var i in Enumerable.Range(0,highestFrequency))
            {
                sets[i] = new BookSet(setSize);
            }
           
            foreach (var position in positionFrequency.OrderByDescending(v=>v.Value.Count))
            {
                for (var i = 0; i < position.Value.Count; i++)
                {
                    var closurePosition = position;
                    var book = closurePosition.Value.ElementAt(i);
                    if (position.Value.Count == 1)
                    {
                        var shortestCandidateSet = ShortestSetWithoutBook(sets, book);
                        shortestCandidateSet.AddBook(book);
                    }
                    else
                    {
                        sets.ElementAt(i).AddBook(book);
                    }
                }
            }
            return sets.ToList();
        }

        private static BookSet ShortestSetWithoutBook(IEnumerable<BookSet> sets, Book book)
        {
            return sets.OrderBy(s => s.Books.Count(b => b != null))
                       .FirstOrDefault(s => !s.ContainsBook(book));
        }

        public override string ToString()
        {
            return string.Format("Book Set containing {0} books", Books.Count(b=>b!=null));
        }
    }
}