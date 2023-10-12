using BookAssignment;
using BookLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookAssignment
{
    [TestClass]
    public class BooksRepositoryDBTest
    {
        private static BooksDBContext? _dbContext;
        private static Ibook _repo;
        private static DbContextOptionsBuilder<BooksDBContext> optionsBuilder;

        [ClassInitialize]
        public static void InitOnce(TestContext context)
        {
            optionsBuilder = new DbContextOptionsBuilder<BooksDBContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Shawal;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        [TestInitialize]
        public void TestSeup()
        {
            _dbContext = new BooksDBContext(optionsBuilder.Options);
            _dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Books");
            _repo = new BooksRepositoryDB(_dbContext);
            _repo.Add(new Book() { Title = "Deep work", Price = 199.99 });
            _repo.Add(new Book() { Title = "Power", Price = 200});
            _repo.Add(new Book() { Title = "The laws of human shawal", Price = 129.99 });
            _repo.Add(new Book() { Title = "48 Laws of power", Price = 400 });
            _repo.Add(new Book() { Title = "The sealed nectar", Price = 300});
        }

        [TestMethod]
        public void AddBookTest()
        {
            
            Book snowWhite = _repo.Add(new Book { Title = "Snehvide", Price = 59.99 });

            Assert.IsTrue(snowWhite.Id >= 0);
            Assert.AreEqual("Snehvide", snowWhite.Title);
            Assert.AreEqual(59.99, snowWhite.Price);

            // Hent alle b�ger fra repository
            IEnumerable<Book> allBooks = _repo.Get();
            Assert.AreEqual(6, allBooks.Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Book? book = _repo.Update(1, new Book { Title = "Harry Potter and the Deathly Hallows", Price = 299.99 });
            Assert.IsNotNull(book);
            Book? book2 = _repo.GetById(1);
            Assert.AreEqual("Harry Potter and the Deathly Hallows", book.Title);

            Assert.IsNull(_repo.Update(-1, new Book { Title = "Buh", Price = 299.99 }));
            Assert.ThrowsException<ArgumentException>(() => _repo.Update(1, new Book { Title = "", Price = 299.99 }));
        }
    }
}