using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDHomeWork.lesson2
{
    public class MyList : ILinkedList
    {
        private Node _headNode = null;

        private Node _taleNode = null;

        private int _count = 0;

        public int GetCount() =>
            _count;

        public void AddNode(int value)
        {
            Node node = new Node() { Value = value };

            if (_headNode == null)
            {
                _headNode = node;
                _taleNode = node;
                _count++;
                return;
            }

            _taleNode.NextNode = node;
            node.PrevNode = _taleNode;
            _taleNode = node;
            _count++;
        }

        public void AddNodeAfter(int value, int index)
        {
            if (!CheckIndex(index))
                return;

            if (_count == 1 || index == _count - 1)
            {
                AddNode(value);
                return;
            }

            Node node = FindByIndex(index);

            Node newNode = new Node() { Value = value };
            Node nextNode = node.NextNode;

            node.NextNode = newNode;
            newNode.NextNode = nextNode;

            newNode.PrevNode = node;
            nextNode.PrevNode = newNode;

            _count++;
        }

        public void AddNodeBefore(int value, int index)
        {
            if (!CheckIndex(index))
                return;

            Node newNode = new Node() { Value = value };

            if (_count == 1)
            {
                newNode.NextNode = _headNode;
                _headNode.PrevNode = newNode;
                _headNode = newNode;

                _count++;
                return;
            }

            Node node = FindByIndex(index);
            Node beforeNode = node.PrevNode;

            node.PrevNode = newNode;
            newNode.PrevNode = beforeNode;

            beforeNode.NextNode = newNode;
            newNode.NextNode = node;

            _count++;
        }

        public void RemoveNodeByIndex(int index)
        {
            if (!CheckIndex(index))
                return;

            if (index == 0)
            {
                RemoveHeadNod();
                return;
            }

            if (index == _count - 1)
            {
                RemoveTailNode();
                return;
            }

            Node node = FindByIndex(index);
            Node nodeAfter = node.NextNode;
            Node nodeBefore = node.PrevNode;

            nodeBefore.NextNode = nodeAfter;
            nodeAfter.PrevNode = nodeBefore;
            _count--;
        }

        public void RemoveNodeByValue(int value)
        {
            Node node;
            if ((node = FindNode(value)) == null)
            {
                Console.WriteLine($"В списке нет элемента со значением {value}");
                Console.ReadKey(true);
                return;
            }

            if (node == _headNode)
            {
                RemoveHeadNod();
                return;
            }

            if (node == _taleNode)
            {
                RemoveTailNode();
                return;
            }

            Node nodeBefore = node.PrevNode;
            Node nodeAfter = node.NextNode;

            nodeBefore.NextNode = nodeAfter;
            nodeAfter.PrevNode = nodeBefore;
            _count--;
        }

        public void BringOutList()
        {
            if (_count == 0)
            {
                Console.WriteLine("Список пуст");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Элементы списка: ");

            if (_count == 1)
            {
                Console.Write(_headNode.Value);
                Console.ReadKey(true);
                return;
            }

            for (Node node = _headNode; node.NextNode != null; node = node.NextNode)
            {
                Console.Write(node.Value + " ");
            }

            Console.Write(_taleNode.Value);
            Console.ReadKey(true);
        }

        public Node FindNode(int serchValue)
        {
            Node node = _headNode;

            do
            {
                if (node.Value == serchValue)
                    return node;
                node = node.NextNode;
            }
            while (node.NextNode != null);

            if (node.Value == serchValue)
                return node;

            return null;
        }

        #region
        private bool CheckIndex(int index)
        {
            if (index >= _count || index < 0 || _count == 0)
            {
                Console.Write("Ошибка : индекс должен быть в диапозоне [0;_count);\nВозможно, список пуст");
                Console.ReadKey(true);
                return false;
            }
            return true;
        }

        private Node FindByIndex(int index)
        {
            int numberElement = 0;
            Node node = _headNode;

            while (numberElement != index)
            {
                numberElement++;
                node = node.NextNode;
            }

            return node;
        }

        private void RemoveHeadNod()
        {
            if (_count == 1)
            {
                _headNode = null;
                _taleNode = null;
                _count--;
                return;
            }

            _headNode = _headNode.NextNode;
            _count--;
        }

        private void RemoveTailNode()
        {
            if (_count == 1)
            {
                _headNode = null;
                _taleNode = null;
                _count--;
            }
            _taleNode = _taleNode.PrevNode;
            _count--;

        }
        #endregion

    }
}
