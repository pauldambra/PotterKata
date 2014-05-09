using System.Collections.Generic;

namespace PotterKata
{
    using System.Linq;

    internal class BookSetPriceCalculator
    {
        private readonly Dictionary<int, decimal> _discountByCount = new Dictionary<int, decimal>
            {
                {2, 0.95M},
                {3, 0.9M},
                {4, 0.8M},
                {5, 0.75M},
            };

        internal decimal GetPriceFor(BookSet bookSet)
        {
            var countOfBooksInSet = bookSet.Books.Count(b => b!=null);
            var discountMultiplier = _discountByCount.ContainsKey(countOfBooksInSet)
                ? _discountByCount[countOfBooksInSet] 
                : 1;
            return (countOfBooksInSet * 8M) * discountMultiplier;
        }
    }
}