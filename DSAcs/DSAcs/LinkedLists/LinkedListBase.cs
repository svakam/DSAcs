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
        public int Size {
            get { return GetSize(); }
            set { }
        }

        private int GetSize()
        {
            if (Head == null) return 0;
            while (Current != null)
            {
                Console.WriteLine(Current.Data);
                Size++;
                Console.WriteLine(Size);
                Current = Current.Next;
            }
            return Size;
        }
    }

    public enum NodeLocation
    {
        BEGINNING,
        END,
        MIDDLE
    }
}
