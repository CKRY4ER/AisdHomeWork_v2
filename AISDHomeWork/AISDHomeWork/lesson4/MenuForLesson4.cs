using AISDHomeWork.lesson4.BinaryT;
using AISDHomeWork.lesson4.HashTb;
using System;
using System.Diagnostics;

namespace AISDHomeWork.lesson4
{
    public class MenuForLesson4
    {
        public void Menu()
        {
            int value;
            string numberOfEx;
            string numberAction;
            BinaryTree tree = new BinaryTree();
            Node newNode;

            while ((numberOfEx = GetNumberOfEx()) != "0")
            {
                switch (numberOfEx)
                {
                    case "1":
                        while ((numberAction = GetTreeAction()) != "0")
                        {
                            switch (numberAction)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.Write("Введите значение для добавления: ");
                                    value = int.Parse(Console.ReadLine());
                                    newNode = new Node { Value = value };

                                    if (tree.AddNode(newNode))
                                        Console.WriteLine("Новый узел успешно добавлен");
                                    else
                                        Console.WriteLine("Узел с таким значением уже есть в дереве");
                                    Console.ReadKey(true);
                                    break;

                                case "2":
                                    Console.Clear();
                                    Console.Write("Введите значение для поиска в дереве: ");
                                    value = int.Parse(Console.ReadLine());

                                    if (tree.FindeNode(value) != null)
                                        Console.WriteLine("Узел с данным значением найден");
                                    else
                                        Console.WriteLine("Узел с данным значением не найден");
                                    Console.ReadKey(true);
                                    break;

                                case "3":
                                    Console.Clear();
                                    Console.Write("Введите значение для удаления: ");
                                    value = int.Parse(Console.ReadLine());

                                    if (tree.DeleteNode(value))
                                        Console.WriteLine("Узел успешно удален");
                                    else
                                        Console.WriteLine("Узла с данным значением нет в дереве");
                                    Console.ReadKey(true);
                                    break;

                                case "4":
                                    Console.Clear();
                                    TreePrinter.Print(tree.Root);
                                    Console.ReadKey(true);
                                    break;

                                default:
                                    break;
                            }
                        }
                        break;

                    case "2":
                        HashTable hashTable;
                        Console.Clear();
                        Console.Write("Введите размерность хеш-таблицы для ручной рабоыт: ");
                        int size = int.Parse(Console.ReadLine());

                        hashTable = new HashTable(size);
                        while((numberAction = GetHashAction()) != "0")
                        {
                            switch (numberAction)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.Write("Введите ключ новой записи: ");
                                    int key = int.Parse(Console.ReadLine());
                                    if (!hashTable.AddInTable(key))
                                    {
                                        Console.WriteLine("Запись не добавлена. Возможно в таблице нет места, или запись с таким ключем уже есть");
                                        Console.ReadKey(true);
                                    }
                                    break;

                                case "2":
                                    Console.Clear();
                                    hashTable.DrawTable();
                                    Console.ReadKey(true);
                                    break;

                                case "3":
                                    Console.Clear();
                                    Console.Write("Введите размерность тестовой таблицы: ");
                                    int sizeTest = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    HashTable testTable = new HashTable(sizeTest);

                                    Stopwatch stopwatchFill = testTable.FillTable();
                                    Console.WriteLine($"Время на заполнение хеш-таблицы размерностью {sizeTest}: {stopwatchFill.Elapsed}");

                                    Stopwatch stopwatchFindeWorse = testTable.FindeWorse();
                                    Console.WriteLine($"Время поиска записи в таблице размерностью {sizeTest} в худшем случае: {stopwatchFindeWorse.Elapsed}");

                                    Stopwatch stopwatchFindeAverage = testTable.FindeAverage();
                                    Console.WriteLine($"Время поиска записи в таблице размерностью {sizeTest} в худшем случае: {stopwatchFindeAverage.Elapsed}");
                                    Console.ReadKey(true);
                                    break;
                            }
                        }
                        break;

                    default:
                        break;
                }
            }

        }

        private string GetNumberOfEx()
        {
            Console.Clear();
            Console.Write("1 - Работа с бинарным деревом поиска\n" +
                "2 - Работа с хеш-таблицей\n" +
                "0 - Выход из урока\n" +
                "Введите действие: ");
            return Console.ReadLine();
        }

        private string GetTreeAction()
        {
            Console.Clear();
            Console.Write("1 - Добавить новый узел\n" +
                "2 - Найти узел в дереве\n" +
                "3 - Удалить узел из дерева\n" +
                "4 - Вывести дерево в консоль\n" +
                "0 - Выход из задания\n" +
                "Введите действие: ");
            return Console.ReadLine();
        }

        private string GetHashAction()
        {
            Console.Clear();
            Console.Write("Для вставки в таблицу используется метод квадратичного исследования. \n" +
                "1 - Добавить случайную запись в таблицу\n" +
                "2 - Вывести таблицу на экран\n" +
                "3 - Провести замеры поиска в таблице ,заполнение таблицы\n" +
                "0 - Выход из задания\n" +
                "Введите действие: ");
            return Console.ReadLine();
        }
    }
}
