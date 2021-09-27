using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.LinkedLists
{
    public abstract class LinkedListBase
    {
        public Node Head { get; set; }
        public Node Current { get; set; }
        public int Size { get; set; }
    }

    public enum NodeLocation
    {
        BEGINNING,
        END,
        MIDDLE
    }
}
