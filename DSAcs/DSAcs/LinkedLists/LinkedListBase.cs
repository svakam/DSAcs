using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.LinkedLists
{
    public abstract class LinkedListBase<T>
    {
        public Node Head { get; set; }
        public Node Current { get; set; }
        public int Size 
        {
            get
            {
                return GetSize();
            }
            set
            { }
        }

        protected LinkedListBase()
        {
            Head = null;
            Current = null;
            Size = 0;
        }

        private int GetSize()
        {
            Node temp = Head;
            if (Head == null) return 0;
            int sizeCounter = 0;
            while (temp != null)
            {
                sizeCounter++;
                temp = temp.Next;
            }
            return sizeCounter;
        }

        protected void ResetCurr()
        {
            Current = Head;
        }
    }

    public enum NodeLocation
    {
        BEGINNING,
        END,
        MIDDLE
    }
}
