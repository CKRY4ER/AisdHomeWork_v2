using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDHomeWork
{
    static public class Lesson1
    {
        public static void Menu()
        {
            string taskNumber = string.Empty;
            while ((taskNumber = GetTaskNumber()) != "0")
            {
                switch (taskNumber)
                {
                    case "1":
                        FuncByScheme();
                        break;
                    case "2":
                        Console.WriteLine("Сложность алгоритма: O(n^3) - кубическая сложность");
                        Console.ReadKey(true); ;
                        break;
                    case "3":
                        Console.Write("Введите число: ");
                        long number = long.Parse(Console.ReadLine());
                        long result = FibWithRecursion(number);
                        Console.WriteLine($"Число Фибоначчи для числа {number}: {result}");
                        Console.ReadKey(true);
                        break;
                    case "4":
                        Console.WriteLine("Введите число: ");
                        number = long.Parse(Console.ReadLine());
                        result = Lesson1.FibWithoutRecursion(number);
                        Console.WriteLine($"Число Фибоначчи для числа {number}: {result}");
                        Console.ReadKey(true);
                        break;
                    default:
                        Console.WriteLine("Не верный ввод. В уроке 1 нет задания с таким номером!");
                        Console.ReadKey(true);
                        break;
                }
            }

        }

        private static void FuncByScheme()
        {
            Console.Write("Введите число: ");

            int number;
            int d = 0;
            int i = 2;
            number = int.Parse(Console.ReadLine());
            while (i < number)

            {
                if (number % i == 0)
                    d++;
                i++;
            }

            if (d == 0)
                Console.WriteLine($"{number} простое");
            else
                Console.WriteLine($"{number} не простое");

            Console.ReadKey(true);
        }

        private static long FibWithRecursion(long number)
        {
            return number > 1 ? FibWithRecursion(number - 1) + FibWithRecursion(number - 2) : number;
        }

        private static long FibWithoutRecursion(long number)
        {
            long[] numbers = new long[number + 1];
            numbers[0] = 0;
            numbers[1] = 1;
            for (int i = 2; i < number + 1; i++)
            {
                numbers[i] = numbers[i - 1] + numbers[i - 2];
            }
            return numbers[number];
        }

        private static string GetTaskNumber()
        {
            Console.Clear();
            Console.Write("1 - Функция, составленная по блок-схеме\n" +
                "2 - Сложность алгоритма\n" +
                "3 - Число Фибоначчи с рекурсией\n" +
                "4 - Число Фибоначчи без рекусии\n" +
                "0 - Выходи из 1-ого урока\n" +
                "Выберите номер задания: ");
            string taskNumber = Console.ReadLine();
            Console.Clear();
            return taskNumber;
        }
    }
}

