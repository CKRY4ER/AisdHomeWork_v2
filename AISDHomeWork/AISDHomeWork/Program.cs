using AISDHomeWork.lesson2;
using System;

namespace AISDHomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numberLesson = String.Empty;

            while ((numberLesson = GetNUmberLesson()) != "0")
            {
                switch (numberLesson)
                {
                    case "1":
                        Lesson1.Menu();
                        break;

                    case "2":
                        MenuForLesson2 lessonMenu = new MenuForLesson2();
                        lessonMenu.Menu();
                        break;

                    default:
                        Console.WriteLine("Не верный ввод. Урока под таким номером не существует!");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        static string GetNUmberLesson()
        {
            Console.Clear();
            Console.Write("1 - Блок-схемы, асимптотическая сложность, рекурсия\n" +
                "2 - Массив, список, поиск\n" +
                "0 - Выход из программы\n" +
                "Выберите номер урока: ");

            string number = Console.ReadLine();

            Console.Clear();

            return number;
        }
    }
}
