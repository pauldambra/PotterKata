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
            var books = new List<Book> {Book.CreateAtPositionInSet(1)};
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(1, sets.Count);
            foreach (var bookSet in sets)
            {
                AssertContentsOfBookSet(bookSet, new[] { Book.CreateAtPositionInSet(1), null, null, null, null });
            }
        }

        [Test]
        public void CanOrderDuplicateBooksIntoDifferentSets()
        {
            var books = new List<Book> { Book.CreateAtPositionInSet(1), Book.CreateAtPositionInSet(1) };
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(2, sets.Count);
            foreach (var bookSet in sets)
            {
                AssertContentsOfBookSet(bookSet, new[] { Book.CreateAtPositionInSet(1), null, null, null, null });    
            }
        }

        [Test]
        public void TwoBooksOfASetAreOrderedIntoTheSameSet()
        {
            var books = new List<Book> { Book.CreateAtPositionInSet(1), Book.CreateAtPositionInSet(2) };
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(1, sets.Count);
            AssertContentsOfBookSet(sets.First(), new[] { Book.CreateAtPositionInSet(1), Book.CreateAtPositionInSet(2), null, null, null });

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
            var books = new List<Book> { Book.CreateAtPositionInSet(1), Book.CreateAtPositionInSet(2), Book.CreateAtPositionInSet(1) };
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(2, sets.Count);
            foreach (var bookSet in sets)
            {
                AssertContentsOfBookSet(sets.First(), new[] { Book.CreateAtPositionInSet(1), Book.CreateAtPositionInSet(2), null, null, null });
            }
        }

        [Test]
        public void GetSensibleErrorMessageWhenAddingBookThatDoesNotFitInSet()
        {
            Assert.Throws<IndexOutOfRangeException>(() => BookSet.OrderBooksIntoSets(new List<Book> { Book.CreateAtPositionInSet(9) }));
        }

        [Test]
        public void OrderingChoosesTheLargestSetsOverMostComplete()
        {
            var books = new List<Book>
                {
                    Book.CreateAtPositionInSet(1),
                    Book.CreateAtPositionInSet(1),
                    Book.CreateAtPositionInSet(2),
                    Book.CreateAtPositionInSet(2),
                    Book.CreateAtPositionInSet(3),
                    Book.CreateAtPositionInSet(3),
                    Book.CreateAtPositionInSet(4),
                    Book.CreateAtPositionInSet(5),
                };
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(2, sets.Count);
            Assert.IsTrue(sets.All(s=>s.Books.Count(b=>b!=null)==4));
        }

        [Test]
        public void OrderingChoosesTheLargestSetsOverMostComplete_WhenThereShouldBeThreeSets()
        {
            var books = new List<Book>
                {
                    Book.CreateAtPositionInSet(1),
                    Book.CreateAtPositionInSet(1),
                    Book.CreateAtPositionInSet(1),
                    Book.CreateAtPositionInSet(2),
                    Book.CreateAtPositionInSet(2),
                    Book.CreateAtPositionInSet(3),
                    Book.CreateAtPositionInSet(3),
                    Book.CreateAtPositionInSet(3),
                    Book.CreateAtPositionInSet(4),
                    Book.CreateAtPositionInSet(4),
                    Book.CreateAtPositionInSet(5),
                };
            //should sort as
            //1,2,3,4
            //1,2,3,4
            //1,3,5
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(3, sets.Count);
            Assert.AreEqual(2, sets.Count(s => s.Books.Count(b => b != null) == 4));
            Assert.AreEqual(1, sets.Count(s => s.Books.Count(b => b != null) == 3));
        }
    }
}