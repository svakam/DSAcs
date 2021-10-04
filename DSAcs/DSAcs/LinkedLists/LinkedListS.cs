using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;
using DSAcs.Base;

namespace DSAcs.LinkedLists
{ // should implement ILinkedList
    public class LinkedListS<T> : LinkedListBase
    {
        public LinkedListS()
        {
            Head = null;
            Current = null;
            Size = 0;
        }

        // add //
        public void Add(T data)
        {
            NodeS node = new(data);
            Add(node);
        }
        public void Add(NodeS node)
        {
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                while (Current.Next != null)
                {
                    Current = Current.Next;
                }
                Current.Next = node;
            }
            Size++;
            ResetCurr();
        }

        // traverse to 1 before the desired insert position, input node gets current.next and current.next gets input
        // edge cases for inserting at 0, 1, and beyond
        public void Add(T data, int n)
        {
            if (n < 0 || (n > Size && Head != null)) throw new ArgumentOutOfRangeException($"Input location {n}: Cannot declare a location input less than 0 for linked lists; location must be 0 < n < LinkedList<T>.Size - 1.");

            NodeS node = new(data);
            Add(node, n);
        }
        public void Add(NodeS node, int n)
        {
            if (n < 0 || n > Size) throw new ArgumentOutOfRangeException($"Input location {n}: Cannot declare a location input less than 0 for linked lists; location must be 0 < n < LinkedList<T>.Size - 1.");

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    Current = Current.Next;
                }
                if (Current.Next == null)
                {
                    Current.Next = node;
                }
                else
                {
                    if (n == 0)
                    {
                        node.Next = Head;
                        Head = node;
                    }
                    else
                    {
                        node.Next = Current.Next;
                        Current.Next = node;
                    }
                }
            }

            Size++;
            ResetCurr();
        }

        public void AddFirst(T data)
        {
            NodeS node = new(data);
            AddFirst(node);
        }
        public void AddFirst(NodeS node)
        {
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
            Size++;
            ResetCurr();
        }

        // remove //
        // by default removes from the end; traverse to 1 before
        public Node Remove()
        {
            if (Head == null) throw new InvalidOperationException("Cannot remove from an empty list.");
            Node temp;
            if (Head.Next == null)
            {
                temp = Head;
                Head = null;
                ResetCurr();
                return temp;
            }

            for (int i = 0; i < Size - 2; i++)
            {
                Current = Current.Next;
            }

            temp = Remove(Current, NodeLocation.END);

            Size--;
            ResetCurr();

            return temp;
        }

        // uses reference node to remove at input location
        // does the actual removal work; handles all cases except null and length-of-1, which are both handled by wrappers
        public Node Remove(Node current, NodeLocation location)
        {
            Node temp;
            switch (location)
            {
                case NodeLocation.END:
                    temp = current.Next;
                    current.Next = null;
                    return temp;

                case NodeLocation.BEGINNING:
                    Head = Head.Next;
                    temp = current;
                    temp.Next = null;
                    return temp;

                case NodeLocation.MIDDLE:
                    Node before = current;
                    current = current.Next;
                    Node after = current.Next;
                    before.Next = after;
                    current.Next = null;
                    return current;
                default:
                    return current;
            }
        }

        // removes all nodes with a value of data from the list
        //public Node Remove(T data)
        //{

        //}

        // removes at specified location from list
        public Node Remove(int n)
        {
            if (n < 0 || n > Size) throw new ArgumentOutOfRangeException($"Input location {n}: Cannot declare a location input less than 0 for linked lists; location must be 0 < n < LinkedList<T>.Size - 1.");
            if (Head == null) throw new InvalidOperationException("Cannot remove from an empty list.");

            Node temp;
            if (Size == 1)
            {
                temp = Head;
                Head = null;
            }
            else if (n == Size - 1)
            {
                for (int i = 0; i < Size - 2; i++)
                {
                    Current = Current.Next;
                }
                temp = Remove(Current, NodeLocation.END);
            }
            else if (n == 0)
            {
                temp = Remove(Current, NodeLocation.BEGINNING);
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    Current = Current.Next;
                }
                temp = Remove(Current, NodeLocation.MIDDLE);
            }

            Size--;
            ResetCurr();
            return temp;
        }

        public Node RemoveFirst()
        {
            if (Head == null) throw new InvalidOperationException("Cannot remove from an empty list.");

            Node temp;
            if (Head.Next == null)
            {
                temp = Head;
                Head = null;
                ResetCurr();
                return temp;
            }

            temp = Remove(Head, NodeLocation.BEGINNING);

            Size--;
            ResetCurr();
            return temp;
        }

        public void Clean()
        {
            Head = null;
            Size = 0;
            ResetCurr();
        }

        // peek//
        public T PeekFirst()
        {
            if (Head == null) throw new InvalidOperationException("Cannot peek on an empty list.");
            return (T) Head.Data;
        }

        public T PeekLast()
        {
            Node temp;
            if (Head == null) throw new InvalidOperationException("Cannot peek on an empty list.");
            for (int i = 0; i < Size - 1; i++)
            {
                Current = Current.Next;
            }
            Console.WriteLine(Current.Data);
            temp = Current;
            ResetCurr();
            return (T) temp.Data;
        }

        public T Peek(int n)
        {
            Node temp;
            if (Head == null) throw new InvalidOperationException("Cannot peek on an empty list.");
            if (n > Size - 1) throw new ArgumentOutOfRangeException("Cannot peek on an index larger than the current size of list.");
            for (int i = 0; i < n; i++)
            {
                Current = Current.Next;
            }
            temp = Current;
            ResetCurr();
            return (T) temp.Data;
        }

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

        private void ResetCurr()
        {
            Current = Head;
        }
    }
}
