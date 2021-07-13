using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;
using DSAcs.LinkedLists;

namespace DSAcs.LinkedLists
{
    public interface ILinkedList
    {
        // add //
        // add last
        public void Add(object data);
        // insert at nth node
        public void Add(object data, int n);
        // add first
        public void AddFirst(object data);

        // remove //
        // remove last
        public Node Remove();
        // remove at n'th node
        public Node Remove(object data, int n);
        // remove first
        public Node RemoveFirst();
        // clean list
        public void Clean();

        // peek //
        // peek first
        public object PeekFirst();
        // peek last
        public object PeekLast();
        // peek n'th node
        public object Peek(int n);

        // merge, split //
        // split at n'th node
        public LinkedList[] Split(int n);
        // merge two lists
        public static LinkedList Merge(LinkedList A, LinkedList B);
        // sort ascending
        public void SortAscending();
        // sort descending
        public void SortDescending();
        // mergesort two lists ascending
        public void MergeSortAscending();
        // mergesort two lists descending
        public void MergeSortDescending();
    }
}
