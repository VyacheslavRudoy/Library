namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;

    public class Reader
    {
        // Поля

        // Счетчик для генерации уникального номера читательского билета
        private static int readerCounter = 1;

        // Уникальный идентификатор читателя
        private readonly int readerId;

        // Имя читателя
        private string firstName;

        // Фамилия читателя
        private string lastName;

        // Отчество читателя
        private string middleName;

        // Дата рождения читателя
        private DateTime dateOfBirth;

        // Номер телефона читателя
        private string phoneNumber;

        // Номер читательского билета
        private int cardNumber;

        // Список книг, которые в данный момент у читателя
        private List<Book> currentlyBorrowedBooks = new List<Book>();

        // Список книг, которые читатель вернул
        private List<Book> returnedBooks = new List<Book>();

        // Конструкторы

        // Конструктор для создания нового читателя
        public Reader(string firstName, string lastName, string middleName, DateTime dateOfBirth, string phoneNumber)
        {
            this.readerId = readerCounter++;
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
            this.cardNumber = GenerateCardNumber();
        }

        // Метод для генерации уникального номера читательского билета
        private int GenerateCardNumber()
        {
            return readerId + 1000;
        }

        // Методы

        // Метод для получения номера читательского билета
        public int GetCardNumber()
        {
            return cardNumber;
        }

        // Метод для аренды книги
        public void BorrowBook(Book book)
        {
            if (book != null && book.Status == "в библиотеке")
            {
                currentlyBorrowedBooks.Add(book);
                book.BorrowBook();
                Console.WriteLine($"{firstName} {lastName} взял(а) книгу '{book.Title}'.");
            }
            else
            {
                Console.WriteLine("Книгу нельзя взять в данный момент.");
            }
        }

        // Метод для возврата книги
        public void ReturnBook(Book book)
        {
            if (book != null && currentlyBorrowedBooks.Contains(book))
            {
                currentlyBorrowedBooks.Remove(book);
                returnedBooks.Add(book);
                book.ReturnBook();
                Console.WriteLine($"{firstName} {lastName} вернул(а) книгу '{book.Title}'.");
            }
            else
            {
                Console.WriteLine("Книгу нельзя вернуть в данный момент.");
            }
        }

        // Метод для отображения взятых книг
        public void DisplayBorrowedBooks()
        {
            Console.WriteLine($"{firstName} {lastName} взял(а) следующие книги:");
            foreach (var book in currentlyBorrowedBooks)
            {
                Console.WriteLine($"- {book.Title} ({book.Author})");
            }
        }

        // Метод для отображения возвращенных книг
        public void DisplayReturnedBooks()
        {
            Console.WriteLine($"{firstName} {lastName} вернул(а) следующие книги:");
            foreach (var book in returnedBooks)
            {
                Console.WriteLine($"- {book.Title} ({book.Author})");
            }
        }

        public string GetFullName()
        {
            return $"{lastName} {firstName} {middleName}";
        }
    }
}