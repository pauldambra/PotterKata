using NUnit.Framework;

namespace PotterKata
{
    public class BookTests
    {
        [Test]
        public void TwoBooksWithTheSameNameAreEqual()
        {
            var left = Book.AtPositionInSet(1);
            var right = Book.AtPositionInSet(1);
            Assert.AreEqual(left, right);
        }

        [Test]
        public void TwoBooksWithDifferentNamesAreNotEqual()
        {
            var left = Book.AtPositionInSet(1);
            var right = Book.AtPositionInSet(2);
            Assert.AreNotEqual(left, right);
        }
    }
}