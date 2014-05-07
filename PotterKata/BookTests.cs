using NUnit.Framework;

namespace PotterKata
{
    public class BookTests
    {
        [Test]
        public void TwoBooksWithTheSameNameAreEqual()
        {
            var left = new Book("first");
            var right = new Book("first");
            Assert.AreEqual(left, right);
        }

        [Test]
        public void TwoBooksWithDifferentNamesAreNotEqual()
        {
            var left = new Book("first");
            var right = new Book("second");
            Assert.AreNotEqual(left, right);
        }
    }
}