using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lib;

namespace libTests
{
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        public void book_addToLibrary_bookInLibrary()
        {
            // arrage
            Book b = new Book(1, "Matan");
            ILibrary lib = new Library();

            // act
            lib.addNewBook(b);

            // assert
            Assert.IsTrue(lib.findAvailableBooks().Contains(b));
        }

        [TestMethod]
        public void book_borrowFromLibrary_bookOutOfLibrary()
        {
            // arrage
            Book b = new Book(1, "Matan");
            ILibrary lib = new Library();
            lib.addNewBook(b);

            // act
            lib.borrowBook(b, "Jay");

            // assert
            Assert.IsFalse(lib.findAvailableBooks().Contains(b));
        }

        [TestMethod]
        [ExpectedException(typeof(LibraryException))]
        public void book_borrowFromLibrary_throwExceptionNotBook()
        {
            // arrage
            Book b = new Book(1, "Matan");
            ILibrary lib = new Library();
            lib.addNewBook(b);

            // act
            lib.borrowBook(b, "Jay");
            lib.borrowBook(b, "Bob");

            // assert is handled by ExpectedException
        }

        [TestMethod]
        public void book_returnToLibrary_bookInLibraryAgain()
        {
            // arrage
            Book b = new Book(1, "Matan");
            ILibrary lib = new Library();
            lib.addNewBook(b);
            lib.borrowBook(b, "Jay");

            // act
            lib.returnBook(b, "Jay");

            // assert
            Assert.IsTrue(lib.findAvailableBooks().Contains(b));
        }

        [TestMethod]
        [ExpectedException(typeof(LibraryException))]
        public void book_returnToLibrary_throwExceptionNotBook()
        {
            // arrage
            Book b = new Book(1, "Matan");
            ILibrary lib = new Library();
            lib.addNewBook(b);
            lib.borrowBook(b, "Jay");

            // act
            lib.returnBook(b, "Jay");
            lib.returnBook(b, "Bob");

            // assert is handled by ExpectedException
        }

        [TestMethod]
        public void findAvailableBooks_ListAvailableBooksInLibrary()
        {
            // arrage
            Book b1 = new Book(1, "Matan");
            Book b2 = new Book(2, "Biology");
            Book b3 = new Book(3, "Physic");
            ILibrary lib = new Library();
            lib.addNewBook(b1);
            lib.addNewBook(b3);

            // act is handled in assert

            // assert
            Assert.IsTrue(lib.findAvailableBooks().Contains(b1));
            Assert.IsFalse(lib.findAvailableBooks().Contains(b2));
            Assert.IsTrue(lib.findAvailableBooks().Contains(b3));
        }
    }
}
