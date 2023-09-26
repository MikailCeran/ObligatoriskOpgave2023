using BookAssignment;

namespace BookTest
{
    [TestClass]
    public class BookTests
    {
        Book _book = new Book() { Id = 1, Title = "Path To Sucess", Price = 1000 }; // Correct Formular

        Book _NullTitleBook = new Book() { Id = 2, Title = null, Price = 900 }; //Title null
        Book _ShortTitleBook = new Book() { Id = 2, Title = "KO", Price = 900 }; //Title under 3Characters

        Book _PriceMaxBook = new Book() { Id = 3, Title = "KO", Price = 1300 }; // Price max value(Limit;1200 Price;1300)
        Book _PriceNormalBook = new Book() { Id = 4, Title = "Get Rich Or Die Trying", Price = 200 }; // Correct book 

        [TestMethod]
        public void ValidateTitleTest()
        {
            _book.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => _NullTitleBook.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => _ShortTitleBook.ValidateTitle());
        }
        [TestMethod]
        public void ValidatePriceTest()
        {
            _book.ValidatePrice();
            Assert.ThrowsException<ArgumentException>((() => _PriceMaxBook.ValidatePrice()));
        }
        [TestMethod]
        public void ToString_ReturnsCorrectString()
        {
            var expectedBook = new Book() { Id = 1, Title = "Path To Sucess", Price = 1000 };
            string actualString = _book.ToString();
            string expectedString = expectedBook.ToString();

            Assert.AreEqual(expectedString, actualString);
        }

    }
}