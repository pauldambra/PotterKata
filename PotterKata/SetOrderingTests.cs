using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PotterKata
{
    using System;

    public class SetOrderingTests
    {
        [Test]
        public void CanOrderASingleBook()
        {
            var books = new List<Book> {Book.AtPositionInSet(1)};
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(1, sets.Count);
            foreach (var bookSet in sets)
            {
                AssertContentsOfBookSet(bookSet, new[] { Book.AtPositionInSet(1), null, null, null, null });
            }
        }

        [Test]
        public void CanOrderDuplicateBooksIntoDifferentSets()
        {
            var books = new List<Book> { Book.AtPositionInSet(1), Book.AtPositionInSet(1) };
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(2, sets.Count);
            foreach (var bookSet in sets)
            {
                AssertContentsOfBookSet(bookSet, new[] { Book.AtPositionInSet(1), null, null, null, null });    
            }
        }

        [Test]
        public void TwoBooksOfASetAreOrderedIntoTheSameSet()
        {
            var books = new List<Book> { Book.AtPositionInSet(1), Book.AtPositionInSet(2) };
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(1, sets.Count);
            AssertContentsOfBookSet(sets.First(), new[] { Book.AtPositionInSet(1), Book.AtPositionInSet(2), null, null, null });

        }

        private static void AssertContentsOfBookSet(BookSet set, params Book[] books)
        {
            for (var i = 0; i < books.Length; i++)
            {
                Assert.AreEqual(set.Books[i],books[i]);
            }
        }

        [Test]
        public void MixedListIsOrderedAsExpected()
        {
            var books = new List<Book> { Book.AtPositionInSet(1), Book.AtPositionInSet(2), Book.AtPositionInSet(1) };
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(2, sets.Count);
            foreach (var bookSet in sets)
            {
                AssertContentsOfBookSet(sets.First(), new[] { Book.AtPositionInSet(1), Book.AtPositionInSet(2), null, null, null });
            }
        }

        [Test]
        public void GetSensibleErrorMessageWhenAddingBookThatDoesNotFitInSet()
        {
            Assert.Throws<IndexOutOfRangeException>(() => BookSet.OrderBooksIntoSets(new[] { Book.AtPositionInSet(9) }));
        }
    }
}