using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDHomeWork.lesson4.HashTb
{
    public class HashTable
    {
        public readonly int size;

        private HashNode[] hashNodes;
        
        public HashTable(int size)
        {
            this.size = size;
            hashNodes = new HashNode[size];
        }

        public bool AddInTable(int key)
        {
            if (CheckKey(key))
                return false;
            Random rand = new Random();
            HashNode node = new HashNode { Value = rand.Next(201), Key = key };
            int hash = HashFunction(key);

            for (int i = 0; i < size; i++)
            {
                //Метод квадратичного исследования: h(key, i) = (h(key) + c1*i + c2*i^2) % size
                int resultI = (hash + 3 * i + 9 * i * i) % size;
                if (hashNodes[resultI] == null)
                {
                    hashNodes[resultI] = node;
                    return true;
                }
            }
            return false;
        }

        public void DrawTable()
        {
            for (int i = 0; i<size; i++)
            {
                if (hashNodes[i] != null)
                {
                    Console.WriteLine($"{hashNodes[i].Key}: {hashNodes[i].Value}");
                    continue;
                }
                Console.WriteLine("Null");
            }
        }

        //Метод измерения времени для заполнения таблицы 
        public Stopwatch FillTable()
        {
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            int count = 0;
            Random rand = new Random();
            sw.Start();
            while (count != size + 1)
            {
                int value = rand.Next(201);
                int key = rand.Next(size*20);

                while (CheckKey(key))
                {
                    key = rand.Next(size*20);
                }
                HashNode node = new HashNode { Key = key, Value = value };
                AddInTableTest(node);
                count++;
            }
            sw.Stop();

            return sw;
        }
        
        /// <summary>
        /// Средний случай
        /// </summary>
        /// <returns></returns>
        public Stopwatch FindeAverage()
        {
            int indexAverage = size / 2;
            HashNode node = hashNodes[indexAverage];
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < size; i++) 
            {
                if (hashNodes[i].Key == node.Key)
                    break;
            }
            sw.Stop();

            return sw;
        }

        /// <summary>
        /// Худший случай
        /// </summary>
        /// <returns></returns>
        public Stopwatch FindeWorse()
        {
            Stopwatch sw = new Stopwatch();
            HashNode node = hashNodes[size - 1];
            sw.Reset();
            sw.Start();
            for (int i = 0; i<size; i++)
            {
                if (hashNodes[i].Key == node.Key)
                {
                    break;
                }
            }
            sw.Stop();

            return sw;
        }

        private void AddInTableTest(HashNode node)
        {
            int hash = HashFunction(node.Key);

            for (long i = 0; i < size; i++)
            {
                //Метод квадратичного исследования: h(key, i) = (h(key) + c1*i + c2*i^2) % size
                long resultI = (hash + 3 * i + 9 * i * i) % size;
                if (hashNodes[((int)resultI)] == null)
                {
                    hashNodes[resultI] = node;
                }
            }
        }

        //Проверка ключа на индивидуальность
        private bool CheckKey(int key)
        {
            for (int i = 0; i < size; i++)
            {
                if (hashNodes[i] != null)
                {
                    if (hashNodes[i].Key == key)
                        return true;
                }
            }
            return false;
        }

        //Хеш функция, остаток от деления
        private int HashFunction(int key)
        {
            int hash = key % size;

            return hash;
        }
    }
}
