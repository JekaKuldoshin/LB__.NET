using System;
using System.Collections.Generic;
using System.Linq;
using Task__3_ClassLibrary;

class ConsoleTest__3
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string[] A = { "Fallout 3", "Daxter 2", "System Shock 2", "Morrowind", "Pes 2013" };
        int[] B = { 2, -7, -10, 6, 7, 9, 3 };
        string[] C = { "Light Green", "Red", "Green", "Yellow", "Purple", "Dark Green", "Light Red", "Dark Red", "Dark Yellow", "Light Yellow" };

        List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
        List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

        var resultA = from item in A where item.Contains("2") select item; //Перебирає кожний item, доки не знайде 2 в контенері
        var positiveNumbers = from number in B where number > 0 select number; //Аналогічно до першого запиту, цей запит
                                                                               //перебирає кожен number в масиві B і вибирає тільки позитивні числа.
        var greenShades = from shade in C where shade.Contains("Green") select shade; //Цей запит перебирає кожен 
        //    shade в масиві C і вибирає тільки ті, які містять підстроку "Green".

        //У мові C# є можливість використовувати LINQ (Language Integrated Query) для обробки колекцій даних, 
        //    таких як масиви, списки і т.д. Синтаксис запитів LINQ надає зручний спосіб фільтрувати, сортувати 
        //    та об'єднувати дані в колекціях.

        //Після виконання цих запитів, вони повертають відфільтровані результати, які потім можна використовувати для 
        //    подальших операцій або виводу в консоль, як показано у вашому коді.

        var cars = new List<Car>
        {
            new Car { Model = "Yugo", MaxSpeed = 180, Color = "Red" },
            new Car { Model = "Aztec", MaxSpeed = 210, Color = "Green" },
            new Car { Model = "BMW", MaxSpeed = 250, Color = "Blue" },
            new Car { Model = "Saab", MaxSpeed = 190, Color = "Black" }
        };

        var products = new List<Product>
        {
            new Product { Name = "Product A", Inventory = 60 },
            new Product { Name = "Product B", Inventory = 40 },
            new Product { Name = "Product C", Inventory = 70 }
        };

        var fastCars = from car in cars where car.MaxSpeed > 200 select car;
        var highInventoryProducts = from product in products where product.Inventory > 50 select product;
        var combinedCars = myCars.Union(yourCars).Distinct();

        Console.WriteLine("Елементи масиву A, які містять '2':");
        foreach (var item in resultA)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nПозитивні елементи масиву B:");
        foreach (var number in positiveNumbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nВідтінки зеленого кольору:");
        foreach (var shade in greenShades)
        {
            Console.WriteLine(shade);
        }

        Console.WriteLine("\nАвтомобілі з максимальною швидкістю більше 200 км/год:");
        foreach (var car in fastCars)
        {
            Console.WriteLine($"Модель: {car.Model}, Швидкість: {car.MaxSpeed}, Колір: {car.Color}");
        }

        Console.WriteLine("\nПродукти з асортиментом більше 50 одиниць:");
        foreach (var product in highInventoryProducts)
        {
            Console.WriteLine($"Назва: {product.Name}, Асортимент: {product.Inventory}");
        }

        Console.WriteLine("\nОб'єднані списки моїх та вашіх автомобілів без повторень:");
        foreach (var car in combinedCars)
        {
            Console.WriteLine(car);
        }
    }
}


