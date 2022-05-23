using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDHomeWork.lesson2
{
    public  interface ILinkedList
    {
        int GetCount();

        void AddNode(int value);

        void AddNodeAfter(int value, int index);

        void AddNodeBefore(int value, int index);

        void RemoveNodeByIndex(int index);

        void RemoveNodeByValue(int value);

        void BringOutList();

        Node FindNode(int serchValue);
    }
}
