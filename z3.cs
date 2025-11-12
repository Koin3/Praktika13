using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starboy3
{
    public class LibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; }

        public LibraryItem(string title, string author, int year, bool isAvailable = true)
        {
            Title = title;
            Author = author;
            Year = year;
            IsAvailable = isAvailable;
        }
    }

    public class Book : LibraryItem
    {
        public int PageCount { get; set; }
        public string ISBN { get; set; }

        public Book(string title, string author, int year, bool isAvailable, int pageCount, string isbn)
            : base(title, author, year, isAvailable)
        {
            PageCount = pageCount;
            ISBN = isbn;
        }
    }

    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }
        public string Frequency { get; set; }

        public Magazine(string title, string author, int year, bool isAvailable, int issueNumber, string frequency)
            : base(title, author, year, isAvailable)
        {
            IssueNumber = issueNumber;
            Frequency = frequency;
        }
    }

    public class DVD : LibraryItem
    {
        public int Duration { get; set; }
        public double Rating { get; set; }

        public DVD(string title, string author, int year, bool isAvailable, int duration, double rating)
            : base(title, author, year, isAvailable)
        {
            Duration = duration;
            Rating = rating;
        }
    }

    public class Audiobook : LibraryItem
    {
        public int Duration { get; set; }
        public string Narrator { get; set; }

        public Audiobook(string title, string author, int year, bool isAvailable, int duration, string narrator)
            : base(title, author, year, isAvailable)
        {
            Duration = duration;
            Narrator = narrator;
        }
    }

    class Program
    {
        static void Main()
        {
            var book = new Book("Дежавю", "Олег Нечипоренко", 2022, true, 230, "978-5-699-07606-4");
            var magazine = new Magazine("National Geographic", "Various", 2023, true, 10, "Ежемесячно");
            var dvd = new DVD("Интерстеллар", "Кристофер Нолан", 2014, false, 169, 8.6);
            var audiobook = new Audiobook("1984", "Джордж Оруэлл", 1949, true, 540, "Иван Иванов");

            Console.WriteLine("Библиотечные материалы");
            Console.WriteLine($"Книга: {book.Title} от {book.Author}, {book.Year}, стр.: {book.PageCount}, ISBN: {book.ISBN}, Доступна: {book.IsAvailable}");
            Console.WriteLine($"Журнал: {magazine.Title}, выпуск #{magazine.IssueNumber}, периодичность: {magazine.Frequency}, Доступен: {magazine.IsAvailable}");
            Console.WriteLine($"DVD: {dvd.Title}, длительность: {dvd.Duration} мин, рейтинг: {dvd.Rating}, Доступен: {dvd.IsAvailable}");
            Console.WriteLine($"Аудиокнига: {audiobook.Title}, диктор: {audiobook.Narrator}, длительность: {audiobook.Duration} мин, Доступна: {audiobook.IsAvailable}");
        }
    }
}
