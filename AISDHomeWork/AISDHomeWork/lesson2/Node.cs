using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDHomeWork.lesson2
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; } = null;
        public Node PrevNode { get; set; } = null;
    }
}
