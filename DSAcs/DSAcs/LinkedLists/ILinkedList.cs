﻿using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;
using DSAcs.LinkedLists;

namespace DSAcs.LinkedLists
{
    public interface ILinkedList<T>
    {
        // create //
        //public void Create(object[] values);

        // add //
        // add last
        public void Add(NodeS node);
        // insert at nth node
        public void Add(T data, int n);
        public void AddFirst(NodeS node);

        // remove //
        // remove last
        public Node Remove();
        // remove at n'th node
        public Node Remove(Node current, NodeLocation location);
        public Node Remove(int n);
        // remove first
        public Node RemoveFirst();
        // clean list
        public void Clean();

        // peek //
        // peek first
        public T PeekFirst();
        // peek last
        public T PeekLast();
        // peek n'th node
        public T Peek(int n);

        // merge, split //
        // split at n'th node
        public Node[] Split(int n);
        // merge two lists
        //public static Node MergeAsc(LinkedListS<T> A, LinkedListS<T> B);


        // other //
        //public int ReturnKthToLast(int k);
        // partition list around value x such that all nodes less than x come before all nodes greater than or equal to x
        //public void Partition(int x);

        //public LinkedListS SumList(LinkedListS A, LinkedListS B);
        //public bool IsPalindrome(LinkedListS list);
        // public bool TwoListsIntersect(LinkedListS A, LinkedListS B);
        // public bool IsCircular();
        //public void MergeSortDescending();
    }
}
