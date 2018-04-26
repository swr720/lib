public class Book <br>
{ <br>
     int id; <br>
     string title; <br>
}

public interface Library      //Институтская библиотека <br>
{ <br>
    void addNewBook(Book book);        //Регистрация новой книги <br>
    void borrowBook(Book book, string student);        //Студент берет книгу <br>
    void returnBook(Book book, string student);        //Студент возвращает книгу <br>
    IList<Book> findAvailableBooks();       //Получить список свободных книг <br>
}
  
Реализуйте интерфейс, который работает с книгой. <br>
Будет плюсом написание простого юнит-теста.
