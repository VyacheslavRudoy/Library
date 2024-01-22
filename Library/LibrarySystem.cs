namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class LibrarySystem
    {
        // Поля

        // Список читателей
        private List<Reader> readers = new List<Reader>();

        // Список книг
        private List<Book> books = new List<Book>();

        // Конструкторы

        // Конструктор по умолчанию
        public LibrarySystem()
        {
            // Инициализация системы библиотеки
            // Здесь можно добавить начальные книги и читателей, если необходимо
        }

        // Методы

        // Метод для добавления нового читателя
        public void AddReader(Reader reader)
        {
            readers.Add(reader);
            Console.WriteLine($"Добавлен новый читатель: {reader.GetCardNumber()} - {reader.GetFullName()}");
        }

        // Метод для удаления читателя
        public void RemoveReader(Reader reader)
        {
            if (readers.Contains(reader))
            {
                readers.Remove(reader);
                Console.WriteLine($"Читатель удален: {reader.GetCardNumber()} - {reader.GetFullName()}");
            }
            else
            {
                Console.WriteLine("Читатель не найден в системе.");
            }
        }

        // Метод для добавления новой книги
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Добавлена новая книга: '{book.Title}' - {book.Author}");
        }

        // Метод для удаления книги
        public void RemoveBook(Book book)
        {
            if (books.Contains(book))
            {
                books.Remove(book);
                Console.WriteLine($"Книга удалена: '{book.Title}' - {book.Author}");
            }
            else
            {
                Console.WriteLine("Книга не найдена в системе.");
            }
        }

        // Метод для поиска книги по автору
        public Book SearchBookByAuthor(string author)
        {
            return books.FirstOrDefault(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
        }

        // Метод для поиска книги по названию
        public Book SearchBookByTitle(string title)
        {
            return books.FirstOrDefault(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        // Метод для бронирования книги читателем
        public void ReserveBook(Reader reader, Book book)
        {
            if (reader != null && book != null)
            {
                reader.BorrowBook(book);
                book.ReserveBook();
            }
        }
    }
}