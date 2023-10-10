using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookAssignment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookTest
{
    [TestClass]
    public class BookRepositoryTests
    {
        private BookRepository _bookRepo;

        [TestInitialize]
        public void Initialize()
        {
            _bookRepo = new BookRepository();
        }

        [TestMethod]
        public void Get_FilterByTitle_Success()
        {
            string titleToFilter = "Rich dad poor dad";

            var filteredBooks = _bookRepo.Get(title: titleToFilter);

            Assert.AreEqual(1, filteredBooks.Count()); 
            Assert.AreEqual(titleToFilter, filteredBooks.First().Title);
        }

        [TestMethod]
        public void Add_Book_Success()
        {
            Book newBook = new Book() { Id = 6, Title = "CSharpEasy", Price = 799.99 };

            var addedBook = _bookRepo.Add(newBook);
            var retrievedBook = _bookRepo.GetById(6);

            Assert.IsNotNull(addedBook);
            Assert.AreEqual(newBook.Id, addedBook.Id);
            Assert.IsNotNull(retrievedBook);
            Assert.AreEqual(newBook.Id, retrievedBook.Id);
        }

        [TestMethod]
        public void Update_ExistingBook_Success()
        {
            int IdToUpdate = 2;
            Book updatedBook = new Book() { Id = IdToUpdate, Title = "Updated Book", Price = 599.99 };

            var result = _bookRepo.Update(IdToUpdate, updatedBook);
            var retrievedBook = _bookRepo.GetById(IdToUpdate);

            Assert.IsNotNull(result);
            Assert.AreEqual(updatedBook.Id, result.Id);
            Assert.IsNotNull(retrievedBook);
            Assert.AreEqual(updatedBook.Id, retrievedBook.Id);
            Assert.AreEqual(updatedBook.Title, retrievedBook.Title);
            Assert.AreEqual(updatedBook.Price, retrievedBook.Price);
        }
         
    }
}
