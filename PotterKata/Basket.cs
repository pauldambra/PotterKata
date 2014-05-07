using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class Basket
    {
        private readonly List<Book> _books = new List<Book>();
        private readonly BookSetPriceCalculator _calculator = new BookSetPriceCalculator();
        
        public decimal Total()
        {
            var sets = BookSet.OrderBooksIntoSets(_books);
            return sets.Sum(set => _calculator.GetPriceFor(set));
        }
        
        public void Add(Book book)
        {
            _books.Add(book);
        }
    }
}