using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.LinkedLists
{
    public abstract class LinkedList
    {
        public Node Head { get; set; }
        public Node Current { get; set; }
        private int _size;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                SetSize();
            }
        }

        protected void SetSize() // LinkedListS inherits this directly, LinkedListD should override
        {
            if (Head == null) _size = 0;

            int size = 0;
            while (Current != null)
            {
                size++;
                Current = Current.Next;
            }
            _size = size;
        }
    }
}
