using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PotterKata
{
    public class SetOrdering
    {
        [Test]
        public void CanOrderASingleBook()
        {
            var books = new List<Book> {new Book("first")};
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(1, sets.Count);
            Assert.AreEqual(books, sets.First().Books);
        }
        [Test]
        public void CanOrderDuplicateBooksIntoDifferentSets()
        {
            var books = new List<Book> { new Book("first"), new Book("first") };
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(2, sets.Count);
            Assert.IsTrue(sets.All(s=>s.Books.Count==1));
            Assert.IsTrue(sets.All(s => s.Books.All(b=>b.Name=="first")));
        }
        [Test]
        public void TwoBooksOfASetAreOrderedIntoTheSameSet()
        {
            var books = new List<Book> { new Book("first"), new Book("second") };
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(1, sets.Count);
            Assert.IsTrue(sets.All(s => s.Books.Count == 2));
        }
        [Test]
        public void MixedListIsOrderedAsExpected()
        {
            var books = new List<Book> { new Book("first"), new Book("second"), new Book("first") };
            var sets = BookSet.OrderBooksIntoSets(books);
            Assert.AreEqual(2, sets.Count);
            var twoBookSet = sets.First(s => s.Books.Count == 2);
            var oneBookSet = sets.First(s => s.Books.Count == 1);
            Assert.IsTrue(oneBookSet.Books.All(b=>b.Name=="first"));
            Assert.AreEqual(new Book("first"), twoBookSet.Books.First(b=>b.Name=="first"));
            Assert.AreEqual(new Book("second"), twoBookSet.Books.Skip(1).First(b => b.Name == "second"));
        }
    }
}