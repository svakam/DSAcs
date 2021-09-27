using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.LinkedLists
{ // should implement ILinkedList
    public class LinkedListS<T> : LinkedList
    {
        public LinkedListS()
        {
            Head = null;
            Current = null;
            Size = 0;
        }

        public void Add(NodeS node)
        {
            if (Head == null)
            {
                Head = node;
                Current = node;
            }
            else
            {
                while (Current.Next != null)
                {
                    Current = Current.Next;
                }
                Current.Next = node;
            } // consider refactoring to an AddBase() and assign property Current to node, then reset Current to null after base is done
        }

        // add //
        public void Add(T data)
        {
            NodeS node = new(data);
            if (Head == null)
            {
                Head = node;
                Current = node;
            }
            else
            {
                while (Current.Next != null)
                {
                    Current = Current.Next;
                }
                Current.Next = node;
            }
        }

        public void Add(NodeS node, int n)
        {
            if (n < 0 || n >= Size) throw new ArgumentOutOfRangeException("Cannot declare a location input less than 0 for linked lists; location must be 0 < n < LinkedList<T>.Size - 1.");
            for (int i = 0; i <=n; i++)
            {

            }
        }

        public void Add(T data, int n)
        {
            if (n < 0 || n >= Size) throw new ArgumentOutOfRangeException("Cannot declare a location input less than 0 for linked lists; location must be 0 < n < LinkedList<T>.Size - 1.");
            NodeS node = new NodeS(data);
        }

        public void AddFirst(T data)
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
