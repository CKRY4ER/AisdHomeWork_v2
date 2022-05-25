using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDHomeWork.lesson3
{
    public class MenuForLesson3
    {
        private PointClassDouble[] classPoints;

        private PointStructDouble[] structPoints;

        public void Menu()
        {
            string action = string.Empty;

            while ((action = GateAction())!="0")
            {
                switch (action)
                {
                    case "1":
                        int numberOfElements;
                        Console.Write("Введите кол-во элементов: ");
                        numberOfElements = int.Parse(Console.ReadLine());
                        MemoryAllocation(numberOfElements);
                        Console.WriteLine("Точки созданны");
                        Console.ReadKey(true);
                        break;

                    case "2":
                        Stopwatch classWatch = DistanceBetweenClassPoints();
                        Stopwatch structWatch = DistanceBetweenStructPoints();
                        Console.WriteLine($"Количество точек: {classPoints.Length}\n" +
                            $"Время работы разчета расстояния на классе: {classWatch.Elapsed}\n" +
                            $"Время работы разчета расстояния на структуре: {structWatch.Elapsed}\n" +
                            $"Отношение времени работы класса к структкуре: {classWatch.Elapsed/structWatch.Elapsed}");
                        Console.ReadKey(true);
                        break;

                    default:
                        Console.WriteLine("Не верный ввод");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        private Stopwatch DistanceBetweenStructPoints()
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            for (int i = 0; i < structPoints.Length - 1; i++)
            {
                for (int j = i + 1; j < structPoints.Length; j++)
                {
                    double result = Math.Sqrt(Math.Pow(structPoints[i].X - structPoints[j].X, 2) +
                        Math.Pow(structPoints[i].Y - structPoints[j].Y, 2));
                }
            }
            watch.Stop();
            return watch;
        }

        private Stopwatch DistanceBetweenClassPoints()
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            for (int i = 0; i < structPoints.Length - 1; i++) 
            {
                for (int j = i + 1; j < structPoints.Length; j++) 
                {
                    double result = Math.Sqrt(Math.Pow(classPoints[i].X - classPoints[j].X, 2) +
                        Math.Pow(classPoints[i].Y - classPoints[j].Y, 2));
                }
            }
            watch.Stop();
            return watch;
        }


        /// <summary>
        /// Выделение памяти и заполнение данными
        /// </summary>
        /// <param name="numberOfElements"></param>
        private void MemoryAllocation(int numberOfElements)
        {
            Random random = new Random();
            classPoints = new PointClassDouble[numberOfElements];
            structPoints = new PointStructDouble[numberOfElements];
            
            byte[] array = new byte[4];
            double x, y;
            for (int i = 0; i < numberOfElements; i++) 
            {
                classPoints[i] = new PointClassDouble();

                random.NextBytes(array);
                x = BitConverter.ToSingle(array, 0);
                y = BitConverter.ToSingle(array, 0);

                classPoints[i].X = x;
                classPoints[i].Y = y;

                structPoints[i].X = x;
                structPoints[i].Y = y;

            }
        }

        private string GateAction()
        {
            string action;

            Console.Clear();
            Console.Write("1 - Выбрать кол-во точек\n" +
                "2 - Выполнить разчет\n" +
                "0 - Выход из урока\n" +
                "Выберите действие: ");
            action = Console.ReadLine();
            Console.Clear();
            return action;
        }
    }
}
