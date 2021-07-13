using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.LinkedLists
{
    class LinkedListS : LinkedList, ILinkedList
    {
        NodeS head;
        NodeS current;
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
                current.A = node;
                current = current.A;
            }
        }

        public void Add(object data, int n)
        {

        }

        public void AddFirst(object data)
        {

        }

        // remove //
        public Node Remove()
        {

        }

        public Node Remove(object data, int n)
        {

        }

        public Node RemoveFirst()
        {

        }

        public void Clean()
        {

        }

        // peek//
        public object PeekFirst()
        {

        }

        public object PeekLast()
        {

        }

        public object Peek(int n)
        {

        }

        // merge, split //
        public LinkedList[] Split(int n)
        {

        }

        public static LinkedList Merge(LinkedListS A, LinkedListS B)
        {

        }

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
