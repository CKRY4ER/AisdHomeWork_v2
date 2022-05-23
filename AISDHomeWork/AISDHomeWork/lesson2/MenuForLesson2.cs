using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDHomeWork.lesson2
{
    public class MenuForLesson2
    {
        public void Menu()
        {
            string action = string.Empty;
            MyList myList = new MyList();
            while ((action = GetActrionNumber()) != "0")
            {
                switch (action)
                {
                    case "1":
                        Console.WriteLine($"Кол-во записей в списке: {myList.GetCount()}");
                        Console.ReadKey(true);
                        break;

                    case "2":
                        Console.Write("Введтите значения для добавления в список: ");
                        int value = int.Parse(Console.ReadLine());
                        myList.AddNode(value);
                        Console.WriteLine("Запись добавлена в список");
                        Console.ReadKey(true);
                        break;

                    case "3":
                        Console.Write("Введте значение для длбавления в список: ");
                        value = int.Parse(Console.ReadLine());
                        Console.Write("Введите индекс элемента: ");
                        int index = int.Parse(Console.ReadLine());
                        myList.AddNodeAfter(value, index);
                        break;

                    case "4":
                        Console.Write("Введте значение для длбавления в список: ");
                        value = int.Parse(Console.ReadLine());
                        Console.Write("Введите индекс элемента: ");
                        index = int.Parse(Console.ReadLine());
                        myList.AddNodeBefore(value, index);
                        break;

                    case "5":
                        Console.Write("Введите индекс элемента для удаления: ");
                        index = int.Parse(Console.ReadLine());
                        myList.RemoveNodeByIndex(index);
                        break;

                    case "6":
                        Console.Write("Введите значение для удаления: ");
                        value = int.Parse(Console.ReadLine());
                        myList.RemoveNodeByValue(value);
                        break;

                    case "7":
                        Console.Write("Введите значение для поиска: ");
                        int serchValue = int.Parse(Console.ReadLine());
                        if (myList.FindNode(serchValue) != null)
                        {
                            Console.Write($"В списке есть записб со значением {serchValue}\n");
                        }
                        else
                        {
                            Console.Write($"В списке нет записи со значением {serchValue}\n");
                        }
                        myList.BringOutList();
                        break;

                    case "8":
                        myList.BringOutList();
                        break;
                    default:
                        Console.WriteLine("Не верный ввод. Действия с таким номером не существует!");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        private string GetActrionNumber()
        {
            Console.Clear();
            Console.Write("1 - Вывести кол-во записей в списке\n" +
                "2 - Добавить запись в список\n" +
                "3 - Добавить запись после индекса\n" +
                "4 - Добавить запись до индекса\n" +
                "5 - Удалить запись по индексу\n" +
                "6 - Удалить запись по значению\n" +
                "7 - Поиск записи по значению\n" +
                "8 - Вывести элементы списка\n" +
                "0 - Выход из урока\n" +
                "Выберите действие: ");
            string action = Console.ReadLine();
            Console.Clear();
            return action;
        }
    }
}

