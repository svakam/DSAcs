using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.LinkedLists
{ // should implement ILinkedList
    class LinkedListS : LinkedList
    {
        NodeS head;
        Node current; // polymorphic 
        // add //
        public void Add(object data)
        {
            NodeS node = new(data);
            if (head == null)
            {
                head = node;
                current = node;
            }
            else
            {
                current.Next = node;
                current = current.Next;
            }
        }

        public void Add(object data, int n)
        {

        }

        public void AddFirst(object data)
        {

        }

        // remove //
        //public Node Remove()
        //{

        //}

        //public Node Remove(object data, int n)
        //{

        //}

        //public Node RemoveFirst()
        //{

        //}

        public void Clean()
        {

        }

        // peek//
        //public object PeekFirst()
        //{

        //}

        //public object PeekLast()
        //{

        //}

        //public object Peek(int n)
        //{

        //}

        // merge, split //
        //public LinkedList[] Split(int n)
        //{

        //}

        //public static LinkedList Merge(LinkedListS A, LinkedListS B)
        //{

        //}

        public void SortAscending()
        {

        }

        public void SortDescending()
        {

        }

        public void MergeSortAscending()
        {

        }

        public void MergeSortDescending()
        {

        }
    }
}
