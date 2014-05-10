using NUnit.Framework;
using PotterKata;

namespace PotterKataTests
{
    public class BookTests
    {
        [Test]
        public void TwoBooksWithTheSameNameAreEqual()
        {
            var left = Book.CreateAtPositionInSet(1);
            var right = Book.CreateAtPositionInSet(1);
            Assert.AreEqual(left, right);
        }

        [Test]
        public void TwoBooksWithDifferentNamesAreNotEqual()
        {
            var left = Book.CreateAtPositionInSet(1);
            var right = Book.CreateAtPositionInSet(2);
            Assert.AreNotEqual(left, right);
        }
    }
}