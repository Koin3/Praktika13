using pepe.EmployeeHierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starboysss1
{
    namespace EmployeeHierarchy
    {
        public class Employee
        {
            public string Name { get; set; }
            public string Position { get; set; }
            protected double Salary;
            public DateTime HireDate { get; set; }

            public Employee(string name, string position, double salary, DateTime hireDate)
            {
                Name = name;
                Position = position;
                Salary = salary;
                HireDate = hireDate;
            }
            public virtual void PrintInfo()
            {
                Console.WriteLine($"Сотрудник: {Name}");
                Console.WriteLine($"Должность: {Position}");
                Console.WriteLine($"Зарплата: {Salary} руб.");
                Console.WriteLine($"Дата приема: {HireDate.ToShortDateString()}");
            }
        }
        public class Manager : Employee
        {
            public int TeamSize { get; set; }

            public Manager(string name, double salary, DateTime hireDate, int teamSize)
                : base(name, "Менеджер", salary, hireDate)
            {
                TeamSize = teamSize;
            }

            public void HoldMeeting()
            {
                Console.WriteLine($"{Name} проводит собрание с командой из {TeamSize} человек.");
            }

            public override void PrintInfo()
            {
                base.PrintInfo();
                Console.WriteLine($"Размер команды: {TeamSize}");
            }
        }
        public class Developer : Employee
        {
            public string ProgrammingLanguage { get; set; }

            public Developer(string name, double salary, DateTime hireDate, string programmingLanguage)
                : base(name, "Разработчик", salary, hireDate)
            {
                ProgrammingLanguage = programmingLanguage;
            }

            public void WriteCode()
            {
                Console.WriteLine($"{Name} пишет код на {ProgrammingLanguage}.");
            }

            public override void PrintInfo()
            {
                base.PrintInfo();
                Console.WriteLine($"Язык программирования: {ProgrammingLanguage}");
            }
        }
        public class Director : Employee
        {
            public string Department { get; set; }

            public Director(string name, double salary, DateTime hireDate, string department)
                : base(name, "Директор", salary, hireDate)
            {
                Department = department;
            }

            public void ApproveBudget()
            {
                Console.WriteLine($"{Name} утверждает бюджет для отдела {Department}.");
            }

            public override void PrintInfo()
            {
                base.PrintInfo();
                Console.WriteLine($"Отдел: {Department}");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Manager manager = new Manager("Ростислав Уткин", 100000, new DateTime(2022, 11, 11), 10);
            Developer developer = new Developer("Кирилл Логинов", 250000, new DateTime(2019, 6, 7), "C#");
            Director director = new Director("Арсений Ли", 550000, new DateTime(2016, 1, 10), "IT");

            manager.PrintInfo();
            manager.HoldMeeting();
            Console.WriteLine();

            developer.PrintInfo();
            developer.WriteCode();
            Console.WriteLine();

            director.PrintInfo();
            director.ApproveBudget();
        }
    }
}
