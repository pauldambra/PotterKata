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
            _basket.Add(new Book("first"));
            var total = _basket.Total();
            Assert.AreEqual(8M, total);
        }
        
        [Test]
        public void CanAddTwoOFTheSameBooksAtSixteenEuros()
        {
            _basket.Add(new Book("first"));
            _basket.Add(new Book("first"));
            var total = _basket.Total();
            Assert.AreEqual(16M, total);
        }

        [Test]
        public void CanAddTwoOFDifferentBookForFivePercentOff()
        {
            _basket.Add(new Book("first"));
            _basket.Add(new Book("second"));
            var total = _basket.Total();
            Assert.AreEqual(15.2M, total);
        }

        [Test]
        public void CanAddMixedBasketAndApplyDiscountToCorrectBooks()
        {
            _basket.Add(new Book("first"));
            _basket.Add(new Book("first"));
            _basket.Add(new Book("second"));
            var total = _basket.Total();
            Assert.AreEqual(23.2M, total);
        }

        [Test]
        public void CanAddThreeDifferentBookForTenPercentOff()
        {
            _basket.Add(new Book("first"));
            _basket.Add(new Book("second"));
            _basket.Add(new Book("third"));
            var total = _basket.Total();
            Assert.AreEqual(21.6M, total);
        }
        
        [Test]
        public void CanAddFourDifferentBookForTwentyPercentOff()
        {
            _basket.Add(new Book("first"));
            _basket.Add(new Book("second"));
            _basket.Add(new Book("third"));
            _basket.Add(new Book("fourth"));
            var total = _basket.Total();
            Assert.AreEqual(25.6M, total);
        }

        [Test]
        public void CanAddFiveDifferentBookForTwentyFivePercentOff()
        {
            _basket.Add(new Book("first"));
            _basket.Add(new Book("second"));
            _basket.Add(new Book("third"));
            _basket.Add(new Book("fourth"));
            _basket.Add(new Book("five"));
            var total = _basket.Total();
            Assert.AreEqual(30M, total);
        }

        [Test]
        public void KataAcceptanceTest()
        {
            _basket.Add(new Book("first"));
            _basket.Add(new Book("first"));
            _basket.Add(new Book("second"));
            _basket.Add(new Book("second"));
            _basket.Add(new Book("third"));
            _basket.Add(new Book("third"));
            _basket.Add(new Book("fourth"));
            _basket.Add(new Book("five"));
            var total = _basket.Total();
            Assert.AreEqual(51.2M, total);
        }
    }
}
