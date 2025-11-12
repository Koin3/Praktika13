using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starboy5
{
    public abstract class Animal
    {
        public string Species { get; protected set; }
        public int Age { get; protected set; }
        public string Habitat { get; protected set; }
        public string Diet { get; protected set; }
        protected Animal(string species, int age, string habitat, string diet)
        {
            Species = species;
            Age = age;
            Habitat = habitat;
            Diet = diet;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Вид: {Species}");
            Console.WriteLine($"Возраст: {Age} лет");
            Console.WriteLine($"Среда обитания: {Habitat}");
            Console.WriteLine($"Рацион: {Diet}");
        }
    }
    public class Mammal : Animal
    {
        public string FurType { get; private set; }
        public int GestationPeriod { get; private set; }

        public Mammal(string species, int age, string habitat, string diet,
                     string furType, int gestationPeriod)
            : base(species, age, habitat, diet)
        {
            FurType = furType;
            GestationPeriod = gestationPeriod;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Тип: Млекопитающее");
            Console.WriteLine($"Тип меха: {FurType}");
            Console.WriteLine($"Продолжительность беременности: {GestationPeriod} месяцев");
        }
    }
    public class Bird : Animal
    {
        public double Wingspan { get; private set; }
        public string NestingType { get; private set; }

        public Bird(string species, int age, string habitat, string diet,
                   double wingspan, string nestingType)
            : base(species, age, habitat, diet)
        {
            Wingspan = wingspan;
            NestingType = nestingType;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Тип: Птица");
            Console.WriteLine($"Размах крыльев: {Wingspan} м");
            Console.WriteLine($"Тип гнездования: {NestingType}");
        }
    }
    public class Reptile : Animal
    {
        public string SkinType { get; private set; }
        public double EnvironmentTemperature { get; private set; }

        public Reptile(string species, int age, string habitat, string diet,
                      string skinType, double environmentTemperature)
            : base(species, age, habitat, diet)
        {
            SkinType = skinType;
            EnvironmentTemperature = environmentTemperature;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Тип: Рептилия");
            Console.WriteLine($"Тип кожи: {SkinType}");
            Console.WriteLine($"Температура среды: {EnvironmentTemperature}°C");
        }
    }
    public class Fish : Animal
    {
        public string ScaleType { get; private set; }
        public double HabitatDepth { get; private set; }
        public Fish(string species, int age, string habitat, string diet,
                   string scaleType, double habitatDepth)
            : base(species, age, habitat, diet)
        {
            ScaleType = scaleType;
            HabitatDepth = habitatDepth;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Тип: Рыба");
            Console.WriteLine($"Тип чешуи: {ScaleType}");
            Console.WriteLine($"Глубина обитания: {HabitatDepth} м");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mammal = new Mammal("Африканский лев", 5, "Саванна", "Плотоядный", "Короткий густой мех", 4);
            var bird = new Bird("Белоголовый орлан", 3, "Леса и побережья", "Плотоядный", 2.1, "Древовидные гнезда");
            var reptile = new Reptile("Королевский питон", 2, "Тропические леса", "Плотоядный", "Чешуйчатая кожа", 28.5);
            var fish = new Fish("Клоун", 1, "Коралловые рифы", "Всеядный", "Мелкая циклоидная", 15.0);

            Console.WriteLine("Система учета животных в зоопарке \n");
            Console.WriteLine("1.Млекопитающее:");
            mammal.DisplayInfo();
            Console.WriteLine("\n2.Птица:");
            bird.DisplayInfo();
            Console.WriteLine("\n3.Рептилия:");
            reptile.DisplayInfo();
            Console.WriteLine("\n4.Рыба:");
            fish.DisplayInfo();
        }
    }
}
