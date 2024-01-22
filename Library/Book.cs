using System;

namespace ClassLibrary2
{
    public class Book
    {
        // Поля

        // Название книги
        private string title;

        // Автор книги
        private string author;

        // Код издания книги
        private int editionCode;

        // Текстовое описание книги
        private string description;

        // Статус книги (в библиотеке, забронирована, на руках)
        private string status;

        // Конструкторы

        // Конструктор для создания новой книги
        public Book(string title, string author, int editionCode, string description)
        {
            this.title = title;
            this.author = author;
            this.editionCode = editionCode;
            this.description = description;
            this.status = "в библиотеке"; // По умолчанию книга находится в библиотеке
        }

        // Методы

        // Метод для изменения статуса книги на "забронирована"
        public void ReserveBook()
        {
            if (status == "в библиотеке")
            {
                status = "забронирована";
                Console.WriteLine($"Книга '{title}' забронирована.");
            }
            else
            {
                Console.WriteLine("Книгу нельзя забронировать в данный момент.");
            }
        }

        // Метод для изменения статуса книги на "на руках"
        public void BorrowBook()
        {
            if (status == "в библиотеке" || status == "забронирована")
            {
                status = "на руках";
                Console.WriteLine($"Книга '{title}' взята на руки.");
            }
            else
            {
                Console.WriteLine("Книгу нельзя взять в данный момент.");
            }
        }

        // Метод для изменения статуса книги на "в библиотеке"
        public void ReturnBook()
        {
            if (status == "на руках")
            {
                status = "в библиотеке";
                Console.WriteLine($"Книга '{title}' возвращена в библиотеку.");
            }
            else
            {
                Console.WriteLine("Книгу нельзя вернуть в данный момент.");
            }
        }

        // Геттер для получения статуса книги
        public string Status
        {
            get { return status; }
        }

        // Геттер для получения названия книги
        public string Title
        {
            get { return title; }
        }

        public string Author
        {
            get { return author; }
        }
    }
}