using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starboy4
{
    public abstract class Course
    {
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Author { get; protected set; }
        public decimal Price { get; protected set; }
        protected Course(string title, string description, string author, decimal price)
        {
            Title = title;
            Description = description;
            Author = author;
            Price = price;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Название: {Title}");
            Console.WriteLine($"Описание: {Description}");
            Console.WriteLine($"Автор: {Author}");
            Console.WriteLine($"Цена: {Price} руб.");
        }
    }
    public class VideoCourse : Course
    {
        public int VideoCount { get; private set; }
        public int TotalDuration { get; private set; }

        public VideoCourse(string title, string description, string author, decimal price,
                          int videoCount, int totalDuration)
            : base(title, description, author, price)
        {
            VideoCount = videoCount;
            TotalDuration = totalDuration;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Тип: Видеокурс");
            Console.WriteLine($"Количество видео: {VideoCount}");
            Console.WriteLine($"Общая длительность: {TotalDuration} минут");
        }
    }
    public class TextCourse : Course
    {
        public int ChapterCount { get; private set; }
        public int TotalTextVolume { get; private set; }

        public TextCourse(string title, string description, string author, decimal price,
                         int chapterCount, int totalTextVolume)
            : base(title, description, author, price)
        {
            ChapterCount = chapterCount;
            TotalTextVolume = totalTextVolume;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Тип:Текстовый курс");
            Console.WriteLine($"Количество глав: {ChapterCount}");
            Console.WriteLine($"Общий объем текста: {TotalTextVolume} страниц");
        }
    }
    public class InteractiveCourse : Course
    {
        public int ExerciseCount { get; private set; }
        public string CheckingSystem { get; private set; }

        public InteractiveCourse(string title, string description, string author, decimal price,
                               int exerciseCount, string checkingSystem)
            : base(title, description, author, price)
        {
            ExerciseCount = exerciseCount;
            CheckingSystem = checkingSystem;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Тип:Интерактивный курс");
            Console.WriteLine($"Количество упражнений: {ExerciseCount}");
            Console.WriteLine($"Система проверки: {CheckingSystem}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var videoCourse = new VideoCourse("C# для начинающих", "Основы программирования на C#", "Максим Сергеевич", 5000, 25, 300);
            var textCourse = new TextCourse("Алгоритмы и структуры данных", "Теоретический курс по алгоритмам", "Сергей Евгеньевич", 3000, 15, 200);
            var interactiveCourse = new InteractiveCourse("Практикум по SQL", "Интерактивный курс по базам данных", "Святослав Федотов", 7000, 50, "Автоматическая проверка заданий");

            Console.WriteLine("Система образовательных курсов\n");
            Console.WriteLine("1. идеокурс:");
            videoCourse.DisplayInfo();
            Console.WriteLine("\n2.Текстовый курс:");
            textCourse.DisplayInfo();
            Console.WriteLine("\n3.Интерактивный курс:");
            interactiveCourse.DisplayInfo();
        }
    }
}
