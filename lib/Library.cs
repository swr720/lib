using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace lib
{
    public class LibraryException : Exception
    {
        public LibraryException(string message) : base(message) { }
    }

    public interface ILibrary
    {
        void addNewBook(Book book);
        void borrowBook(Book book, string student);
        void returnBook(Book book, string student);
        IList<Book> findAvailableBooks();
    }

    public class Book
    {
        public string Title { get; set; }
        public int Id { get; set; }

        public Book(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Book b = obj as Book;

            if (b as Book == null)
            {
                return false;
            }

            return b.Title == this.Title && b.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() + this.Title.GetHashCode();
        }
    }

    public class Library : ILibrary
    {
        private List<Book> availableBooks = new List<Book>();
        private Dictionary<Book, string> studentMap = new Dictionary<Book, string>();

        public void addNewBook(Book book)
        {
            availableBooks.Add(book);
        }

        public void borrowBook(Book book, string student)
        {
            if (book == null)
            {
                throw new LibraryException("Book is null");
            }
            else if (student == null)
            {
                throw new LibraryException("Student is null");
            }
            else if (availableBooks.Contains(book))
            {
                studentMap.Add(book, student);
                availableBooks.Remove(book);
            }
            else
            {
                throw new LibraryException($"Not found <{book.Id}><{book.Title}> in Library");
            }
        }

        public void returnBook(Book book, string student)
        {
            studentMap.TryGetValue(book, out string value);

            if (book == null)
            {
                throw new LibraryException("Book is null");
            }
            else if (student == null)
            {
                throw new LibraryException("Student is null");
            }
            else if (student == value)
            {
                studentMap.Remove(book);
                availableBooks.Add(book);
            }
            else
            {
                throw new LibraryException($"{student} didn't take <{book.Id}><{book.Title}>");
            }
        }

        public IList<Book> findAvailableBooks()
        {
            IList<Book> availableBooksRO = new ReadOnlyCollection<Book>(availableBooks);
            return availableBooksRO;
        }
    }
}