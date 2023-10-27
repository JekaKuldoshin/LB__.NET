using System;
using NUnit.Framework;
using Task__1_ClassLibrary;

namespace ConsoleTest__1
{
    class ConsoleTest__1
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Запускаем тесты и сохраняем результаты
            ExtensionsTests tests = new ExtensionsTests();
            tests.StringReverseTest();
            tests.StringCountOccurrencesTest();
            tests.ArrayCountOccurrencesTest();
            tests.ArrayRemoveDuplicatesTest();

            // Печатаем результаты тестов
            Console.WriteLine($"\n\nStringReverseTest - Інвертування рядка: {(tests.StringReversePassed ? "Passed" : "Failed")}");
            Console.WriteLine($"StringCountOccurrencesTest - Скільки разів символ зустрічається в рядку: {(tests.StringCountOccurrencesPassed ? "Passed" : "Failed")}");
            Console.WriteLine($"ArrayCountOccurrencesTest - Скільки разів число зустрічається в массиві: {(tests.ArrayCountOccurrencesPassed ? "Passed" : "Failed")}");
            Console.WriteLine($"ArrayRemoveDuplicatesTest - Видалення дублікатів і перевірка з правильним массивом: {(tests.ArrayRemoveDuplicatesPassed ? "Passed" : "Failed")}");

            // Ожидаем нажатия клавиши перед закрытием консоли
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }



    [TestFixture]
    public class ExtensionsTests
    {
        public bool StringReversePassed { get; private set; }
        public bool StringCountOccurrencesPassed { get; private set; }
        public bool ArrayCountOccurrencesPassed { get; private set; }
        public bool ArrayRemoveDuplicatesPassed { get; private set; }

        public void StringReverseTest()
        {
            string input = "hello";
            string reversed = input.Reverse();
            StringReversePassed = reversed == "olleh";
            Console.WriteLine(reversed);

        }

        public void StringCountOccurrencesTest()
        {
            string input = "hello";
            int count = input.CountOccurrences('l');
            StringCountOccurrencesPassed = count == 2;
            Console.WriteLine(count);
        }

        public void ArrayCountOccurrencesTest()
        {
            int[] numbers = { 1, 2, 3, 4, 2, 5, 2 };
            int count = numbers.CountOccurrences(2);
            ArrayCountOccurrencesPassed = count == 3;
            Console.WriteLine(count);
        }

        public void ArrayRemoveDuplicatesTest()
        {
            int[] numbers = { 1, 2, 3, 4, 2, 5, 2 };
            int[] uniqueNumbers = numbers.RemoveDuplicates();
            ArrayRemoveDuplicatesPassed = uniqueNumbers.SequenceEqual(new int[] { 1, 2, 3, 4, 5 });
            Console.Write("Unique numbers:");
            foreach (var number in uniqueNumbers)
            {
                Console.Write(number);
            }

        }
    }
}
