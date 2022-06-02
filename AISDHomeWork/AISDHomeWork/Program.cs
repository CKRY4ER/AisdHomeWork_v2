using AISDHomeWork.lesson2;
using AISDHomeWork.lesson3;
using AISDHomeWork.lesson4;
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

                    case "3":
                        MenuForLesson3 menuForLesson3 = new MenuForLesson3();
                        menuForLesson3.Menu();
                        break;

                    case "4":
                    case "5":
                        MenuForLesson4 menuForLesson4 = new MenuForLesson4();
                        menuForLesson4.Menu();
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
                "3 - Класс, структура и дистанция\n" +
                "4 - Деревья, хэш-таблицы\n" +
                "5 - Стек, очередь, словарь и коллекции в C#\n" +
                "0 - Выход из программы\n" +
                "Выберите номер урока: ");

            string number = Console.ReadLine();

            Console.Clear();

            return number;
        }
    }
}
