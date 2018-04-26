public class Book { 
     int id; 
     String title; 
}
/ Институтская библиотека / 
public interface Library { 
    / Регистрация новой книги / 
    void addNewBook(Book book); 
    / Студент берет книгу / 
    void borrowBook(Book book, String student); 
    / Студент возвращает книгу / 
    void returnBook(Book book, String student); 
    / Получить список свободных книг / 
    IList<Book> findAvailableBooks(); 
}
  
Реализуйте интерфейс, который работает с книгой.
