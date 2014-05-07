using System.Collections.Generic;

namespace PotterKata
{
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
            var discountMultiplier = _discountByCount.ContainsKey(bookSet.Books.Count) 
                ? _discountByCount[bookSet.Books.Count] 
                : 1;
            return (bookSet.Books.Count*8M)*discountMultiplier;
        }
    }
}