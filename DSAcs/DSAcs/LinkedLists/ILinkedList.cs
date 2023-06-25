using System.Linq;
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


        public void Add(NodeS node);
        // insert at nth node
        public void Add(T data, int n);
        public void AddFirst(NodeS node);

        public NodeS Remove();
        public NodeS Remove(int n);
        public NodeS RemoveFirst();

        public void Clean();


        public T PeekFirst();

        public T PeekLast();

        public T Peek(int n);

        // merge, split //
        // split at n'th node
        //public Node[] Split(int n);

        //public Node MergeAsc(LinkedListS<T> A, LinkedListS<T> B);

        // other //
        public bool IsLoop();
        //public Node RemoveKthNodeFromEnd(int k);
        //public Node GetIntersectionOfTwoListsSimple(LinkedListS<T> a, LinkedListS<T> b);
        //public Node GetIntersectionOfTwoListsStack(LinkedListS<T> a, LinkedListS<T> b);
        // partition list around value x such that all nodes less than x come before all nodes greater than or equal to x
        //public void Partition(int x);

        //public LinkedListS SumList(LinkedListS A, LinkedListS B);
        //public bool IsPalindrome(LinkedListS list);

        // enumeration //
        // public void MoveNext();
    }
}
