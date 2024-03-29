﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;
using DSAcs.Base;
using DSAcs.Stack;

namespace DSAcs.LinkedLists
{ // should implement ILinkedList
    public class LinkedListS<T> : LinkedListBase<T>, ILinkedList<T>
    {
        public LinkedListS() : base() { }

        // -------- add -------- //

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
            ResetCurr();
        }
        public void Add(T data, int n)
        {
            if (n < 0 || (n > Size && Head != null)) throw new ArgumentOutOfRangeException($"Input location {n}: Cannot declare a location input less than 0 for linked lists; location must be 0 < n < LinkedList<T>.Size - 1.");

            NodeS node = new(data);
            Add(node, n);
        }
        public void Add(NodeS node, int n)
        {
            if (n < 0 || n > Size) throw new ArgumentOutOfRangeException($"Invalid insert location {n}: insert location must be 0 < n < LinkedListBase<T>.Size - 1.");

            if (Head == null)
            {
                Head = node;
                ResetCurr();
                return;
            }
            if (n == 0)
            {
                AddFirst(node);
                return;
            }
            for (int i = 0; i < n - 1; i++)
            {
                Current = Current.Next;
            }
            if (Current.Next != null)
            {
                node.Next = Current.Next;
            }
            Current.Next = node;

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
            ResetCurr();
        }

        // remove //
        // by default removes from the end; traverse to 1 before
        public NodeS Remove()
        {
            if (Head == null) throw new InvalidOperationException("Cannot remove from an empty list.");
            int n = Size;
            NodeS temp;
            if (Head.Next == null)
            {
                temp = (NodeS) Head;
                Head = null;
                ResetCurr();
                return temp;
            }

            for (int i = 0; i < n - 2; i++) // 
            {
                Current = Current.Next;
            }
            temp = (NodeS) Current.Next;
            Current.Next = null;

            ResetCurr();

            return temp;
        }

        // removes at specified location from list
        public NodeS Remove(int n)
        {
            int size = Size;
            if (n < 0 || n >= size) throw new ArgumentOutOfRangeException($"Input location {n}: Cannot declare a location input less than 0 for linked lists; location must be 0 < n < LinkedList<T>.Size - 1.");
            if (Head == null) throw new InvalidOperationException("Cannot remove from an empty list.");

            NodeS temp;

            if (size == 1)
            {
                temp = (NodeS) Head;
                Head = null;
                return temp;
            }
            if (n == 0)
            {
                temp = (NodeS)Current;
                Head = Current.Next;
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    Current = Current.Next;
                }
                temp = (NodeS)Current.Next;
                Current.Next = temp.Next;
                temp.Next = null;
            }

            ResetCurr();
            return temp;
        }

        public NodeS RemoveFirst()
        {
            if (Head == null) throw new InvalidOperationException("Cannot remove from an empty list.");

            NodeS temp = (NodeS) Head;
            if (Head.Next == null)
            {
                Head = null;
                ResetCurr();
                return temp;
            }

            Head = Head.Next;
            temp.Next = null;
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
            int size = Size;
            Node temp;
            if (Head == null) throw new InvalidOperationException("Cannot peek on an empty list.");
            for (int i = 0; i < size - 1; i++)
            {
                Current = Current.Next;
            }
            temp = Current;
            ResetCurr();
            return (T) temp.Data;
        }

        public T Peek(int n)
        {
            int size = Size;
            Node temp;
            if (Head == null) throw new InvalidOperationException("Cannot peek on an empty list.");
            if (n > size - 1) throw new ArgumentOutOfRangeException("Cannot peek on an index larger than the current size of list.");
            for (int i = 0; i < n; i++)
            {
                Current = Current.Next;
            }
            temp = Current;
            ResetCurr();
            return (T) temp.Data;
        }

        // merge, split //
        // split list after nth index
        public NodeS[] Split(int n)
        {
            int size = Size;
            // if list size is smaller than 2, can't split
            if (size < 2) throw new InvalidOperationException("Cannot split a list with a size smaller than 1.");
            
            LLNode[] heads;
            // if index is at the end, no splitting required; return the full list
            if (n == size - 1)
            {
                heads = new NodeS[1];
                heads[0] = Head;
                return (NodeS[]) heads;
            }

            heads = new NodeS[2];
            heads[0] = Head;
            for (int i = 0; i < n; i++)
            {
                Current = Current.Next;
            }
            NodeS head2 = (NodeS) Current.Next;
            Current.Next = null;
            heads[1] = head2;
            return (NodeS[]) heads;
        }

        // merge two sorted lists in-place and return head of sorted list
        public NodeS MergeAsc(LinkedListS<T> A, LinkedListS<T> B)
        {
            // Head of each list will act as runner to optimize memory

            // if both lists are empty, then merged list is also empty
            // if one of the lists is empty, then merged list is the other list
            if (A.Head == null) return (NodeS) B.Head;
            if (B.Head == null) return (NodeS) A.Head;

            // set head to smallest
            NodeS mergedHead;
            if ((int)A.Head.Data <= (int)B.Head.Data)
            {
                mergedHead = (NodeS) A.Head;
                A.Head = A.Head.Next;
            }
            else
            {
                mergedHead = (NodeS) B.Head;
                B.Head = B.Head.Next;
            }

            // start tail
            NodeS mergedTail = mergedHead;

            // create merged list while neither heads are null
            while (A.Head != null && B.Head != null)
            {
                // set a temp holder to least value between the heads so the head can be moved up to compare the next two
                NodeS temp;
                if ((int)A.Head.Data <= (int)B.Head.Data)
                {
                    temp = (NodeS) A.Head;
                    A.Head = A.Head.Next;
                }
                else
                {
                    temp = (NodeS) B.Head;
                    B.Head = B.Head.Next;
                }

                // set what the tail's pointing to to where temp is and set the tail to temp; this orders the merged list and sets tail to end of current merged list
                mergedTail.Next = temp;
                mergedTail = temp;
            }

            // if one of the heads aren't null, set what merged tail's next ref to the head
            if (A.Head != null)
            {
                mergedTail.Next = A.Head;
            }
            else if (B.Head != null)
            {
                mergedTail.Next = B.Head;
            }

            // return the merged head
            return mergedHead;
        }

        // Floyd's cycle-finding algorithm
        // set fast current to traverse list twice as fast; while neither pointers are still on a node and fast current's next is a node, move tracers
        // and check for landing on same node; fast will eventually catch up with slow if it's a cycle
        public bool IsLoop()
        {
            NodeS FastCurrent = (NodeS) Head;
            int loopsDone = 0;
            while (Current != null && FastCurrent != null && FastCurrent.Next != null)
            {
                Current = Current.Next;
                FastCurrent = (NodeS) FastCurrent.Next.Next;
                if (Current == FastCurrent) return true;
                loopsDone++;
            }
            Console.WriteLine($"loops done: {loopsDone}");
            return false;
        }

        public NodeS RemoveKthNodeFromEnd(int k)
        {
            int size = Size;
            if (k > size) throw new ArgumentOutOfRangeException("Cannot remove a node out of range of this list.");
            int numTimesToTraverse = size - k;

            NodeS removed;
            for (int i = 0; i < numTimesToTraverse; i++)
            {
                Current = Current.Next;
            }
            removed = RemoveAtCurrentOnly((NodeS) Current);
            return removed;
        }

        // keep ref to next node, copy data from next into current (effectively 'removing' this data) and point to next's next
        public NodeS RemoveAtCurrentOnly(NodeS current)
        {
            if (current.Next == null) throw new InvalidOperationException("Cannot remove at current only at the last node of hte list.");
            NodeS temp = (NodeS) current.Next;
            
            // swap step isn't necessary, but useful for testing; swap the removed val into temp (later removed)
            object removedVal = temp.Data;
            temp.Data = current.Data;
            current.Data = removedVal;

            current.Next = temp.Next;
            temp.Next = null;
            return temp;
        }

        public Node GetIntersectionOfTwoListsSimple(LinkedListS<T> a, LinkedListS<T> b)
        {
            // get size difference
            // move pointer on longer list up by difference
            // move both pointers up by 1 until intersection found, else return null

            int lengthDiffAFromB = a.Size - b.Size;
            bool aLongerThanB = false;
            if (lengthDiffAFromB < 0) aLongerThanB = true;
            int lengthDiff = Math.Abs(lengthDiffAFromB);

            if (lengthDiff != 0)
            {
                if (aLongerThanB)
                {
                    for (int i = 0; i < lengthDiff; i++)
                    {
                        a.Current = a.Current.Next;
                    }
                }
                else
                {
                    for (int i = 0; i < lengthDiff; i++)
                    {
                        b.Current = b.Current.Next;
                    }
                }
            }

            while (a.Current != null & b.Current != null)
            {
                if (a.Current == b.Current) return a.Current;
                a.Current = a.Current.Next;
                b.Current = b.Current.Next;
            }
            return null;
        }

        // push each list - node by node - to its own stack, with node addresses as data of stack
        // pop a node off each list simultaneously
        // if addresses match between each popped, store in temp variable and continue popping
        // when addresses don't match, the temp variable holds the first intersecting node; return it
        public static Node GetIntersectionOfTwoListsStack(LinkedListS<T> a, LinkedListS<T> b)
        {
            // for an intersection to occur, there must be two lists
            // assumption made that two lists can technically exist if two pointers point to the same head of a 'list'
            if (a == null || b == null) return null;

            Stack<T> stackA = new();
            Stack<T> stackB = new();

            while (a.Current != null)
            {
                stackA.Push((NodeS)a.Current);
                a.Current = a.Current.Next;
            }
            while (b.Current != null)
            {
                stackB.Push((NodeS)b.Current);
                b.Current = b.Current.Next;
            }

            Node intersection = null;

            int counter = 1;
            if (stackA.Top == stackB.Top)
            {
                System.Diagnostics.Debug.WriteLine($"a{counter}: {stackA.Top.Data}");
                System.Diagnostics.Debug.WriteLine($"b{counter}: {stackB.Top.Data}");
                Node poppedA = stackA.Pop();
                Node poppedB = stackB.Pop();
                System.Diagnostics.Debug.WriteLine($"a{counter}: {poppedA.Data}");
                System.Diagnostics.Debug.WriteLine($"b{counter}: {poppedB.Data}");
                counter++;

                if (poppedA == poppedB)
                {
                    intersection = poppedA;
                }
            }

            return intersection;
        }
    }
}
