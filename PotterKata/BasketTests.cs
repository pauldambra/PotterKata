using NUnit.Framework;

namespace PotterKata
{
    public class BasketTests
    {
        private Basket _basket;

        [SetUp]
        public void SetUp()
        {
            _basket = new Basket();
        }

        [Test]
        public void AnEmptyBasketHasZeroTotal()
        {
            var total = _basket.Total();
            Assert.AreEqual(0M,total);
        }

        [Test]
        public void CanAddABookAtEightEuros()
        {
            _basket.Add(Book.CreateAtPositionInSet(1));
            var total = _basket.Total();
            Assert.AreEqual(8M, total);
        }
        
        [Test]
        public void CanAddTwoOFTheSameBooksAtSixteenEuros()
        {
            _basket.Add(Book.CreateAtPositionInSet(1));
            _basket.Add(Book.CreateAtPositionInSet(1));
            var total = _basket.Total();
            Assert.AreEqual(16M, total);
        }

        [Test]
        public void CanAddTwoOFDifferentBookForFivePercentOff()
        {
            _basket.Add(Book.CreateAtPositionInSet(1));
            _basket.Add(Book.CreateAtPositionInSet(2));
            var total = _basket.Total();
            Assert.AreEqual(15.2M, total);
        }

        [Test]
        public void CanAddMixedBasketAndApplyDiscountToCorrectBooks()
        {
            _basket.Add(Book.CreateAtPositionInSet(1));
            _basket.Add(Book.CreateAtPositionInSet(1));
            _basket.Add(Book.CreateAtPositionInSet(2));
            var total = _basket.Total();
            Assert.AreEqual(23.2M, total);
        }

        [Test]
        public void CanAddThreeDifferentBookForTenPercentOff()
        {
            _basket.Add(Book.CreateAtPositionInSet(1));
            _basket.Add(Book.CreateAtPositionInSet(2));
            _basket.Add(Book.CreateAtPositionInSet(3));
            var total = _basket.Total();
            Assert.AreEqual(21.6M, total);
        }
        
        [Test]
        public void CanAddFourDifferentBookForTwentyPercentOff()
        {
            _basket.Add(Book.CreateAtPositionInSet(1));
            _basket.Add(Book.CreateAtPositionInSet(2));
            _basket.Add(Book.CreateAtPositionInSet(3));
            _basket.Add(Book.CreateAtPositionInSet(4));
            var total = _basket.Total();
            Assert.AreEqual(25.6M, total);
        }

        [Test]
        public void CanAddFiveDifferentBookForTwentyFivePercentOff()
        {
            _basket.Add(Book.CreateAtPositionInSet(1));
            _basket.Add(Book.CreateAtPositionInSet(2));
            _basket.Add(Book.CreateAtPositionInSet(3));
            _basket.Add(Book.CreateAtPositionInSet(4));
            _basket.Add(Book.CreateAtPositionInSet(5));
            var total = _basket.Total();
            Assert.AreEqual(30M, total);
        }

        [Test]
        public void KataAcceptanceTest()
        {
            _basket.Add(Book.CreateAtPositionInSet(1));
            _basket.Add(Book.CreateAtPositionInSet(1));
            _basket.Add(Book.CreateAtPositionInSet(2));
            _basket.Add(Book.CreateAtPositionInSet(2));
            _basket.Add(Book.CreateAtPositionInSet(3));
            _basket.Add(Book.CreateAtPositionInSet(3));
            _basket.Add(Book.CreateAtPositionInSet(4));
            _basket.Add(Book.CreateAtPositionInSet(5));
            var total = _basket.Total();
            Assert.AreEqual(51.2M, total);
        }
    }
}
