using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSAcs.LinkedLists;

namespace DSATest
{
    [TestClass]
    public class LinkedListTestsS : LinkedListTestsBase
    {
        LinkedListS<int> ll;

        [TestMethod]
        public override void TestInstantiation()
        {
            ll = new();
            Assert.IsNotNull(ll);
            Assert.IsNull(ll.Head);
            Assert.IsNull(ll.Current);
        }

        [TestMethod]
        public override void TestAdd()
        {
            // test default add last
            ll = new();
            Assert.IsNull(ll.Head);
            Assert.IsNull(ll.Current);
            ll.Add(2);
            Assert.AreEqual(2, ll.Head.Data);
            ll.Add(new NodeS(3));
            Assert.AreEqual(2, ll.Head.Data);
            Assert.AreEqual(3, ll.Head.Next.Data);

            // test add at nth location in list
            LinkedListS<int> ll2 = new();
            // assert throws exception if adding at a location larger than size or negative n
            ll2.Add(2, 0);
            Assert.AreEqual(2, ll2.Head.Data);
            ll2.Add(3, 1);
            Assert.AreEqual(2, ll2.Head.Data);
            Assert.AreEqual(3, ll2.Head.Next.Data);
            ll2.Add(4, 1);
            Assert.AreEqual(2, ll2.Head.Data);
            Assert.AreEqual(4, ll2.Head.Next.Data);
            Assert.AreEqual(3, ll2.Head.Next.Next.Data); // order is 243 here
            ll2.Add(5, 0);
            Assert.AreEqual(5, ll2.Head.Data); // 5243
            Assert.AreEqual(2, ll2.Head.Next.Data);
            Assert.AreEqual(4, ll2.Head.Next.Next.Data);
            Assert.AreEqual(3, ll2.Head.Next.Next.Next.Data);
            ll2.Add(6, 4); // 52436
            Assert.AreEqual(6, ll2.Head.Next.Next.Next.Next.Data);
            ll2.AddFirst(7); // 752436
            Assert.AreEqual(7, ll2.Head.Data);
            Assert.AreEqual(5, ll2.Head.Next.Data);
            Assert.AreEqual(2, ll2.Head.Next.Next.Data);
            // test for out of range
        }

        [TestMethod]
        public override void TestRemoveAndClean()
        {
            Node s;
            ll = new();
            ll.AddFirst(5);
            ll.AddFirst(2);
            ll.Add(3); 
            ll.Add(4);
            ll.Add(7);
            ll.Add(9);
            ll.Add(8); // 2534798
            s = ll.Remove(); // 253479
            Assert.IsNotNull(s);
            Assert.AreEqual(8, s.Data);
            Assert.AreEqual(2, ll.Head.Data);
            Assert.AreEqual(5, ll.Head.Next.Data);
            s = ll.RemoveFirst(); // 53479
            Assert.AreEqual(2, s.Data);
            Assert.AreEqual(5, ll.Head.Data);
            Assert.AreEqual(3, ll.Head.Next.Data);
            s = ll.Remove(0); // 3479
            Assert.AreEqual(5, s.Data);
            Assert.AreEqual(3, ll.Head.Data);
            Assert.AreEqual(4, ll.Head.Next.Data);
            s = ll.Remove(2); // 349
            Assert.AreEqual(7, s.Data);
            Assert.AreEqual(3, ll.Head.Data);
            Assert.AreEqual(4, ll.Head.Next.Data);
            Assert.AreEqual(9, ll.Head.Next.Next.Data);
            s = ll.Remove(2); // 34
            Assert.AreEqual(9, s.Data);
            Assert.AreEqual(3, ll.Head.Data);
            Assert.AreEqual(4, ll.Head.Next.Data);
            ll.Add(10);
            ll.Add(11);
            ll.Add(12);
            ll.Clean();
            Assert.IsNull(ll.Head);
            Assert.IsNull(ll.Current);
            
        }

        [TestMethod]
        public override void TestSize()
        {
            ll = new();
            Assert.AreEqual(0, ll.Size);
            ll.Add(100);
            Assert.AreEqual(1, ll.Size);
            ll.Add(3);
            Assert.AreEqual(2, ll.Size);
            ll.Add(4, 1);
            Assert.AreEqual(3, ll.Size);
            ll.AddFirst(5);
            Assert.AreEqual(4, ll.Size);
            ll.Remove();
            Assert.AreEqual(3, ll.Size);
            ll.RemoveFirst();
            Assert.AreEqual(2, ll.Size);
            ll.Remove(0);
            Assert.AreEqual(1, ll.Size);
        }

        [TestMethod]
        public override void TestPeek()
        {
            ll = new();
            // test peek on null list, greater than size, etc.
            ll.Add(2);
            Assert.AreEqual(2, ll.PeekLast());
            Assert.AreEqual(2, ll.PeekFirst());
            Assert.AreEqual(2, ll.Peek(0));
            ll.Add(3);
            Assert.AreEqual(2, ll.PeekFirst());
            Assert.AreEqual(3, ll.Peek(1));
            Assert.AreEqual(3, ll.PeekLast());
            ll.Add(4);
            Assert.AreEqual(2, ll.PeekFirst());
            Assert.AreEqual(2, ll.Peek(0));
            Assert.AreEqual(3, ll.Peek(1));
            Assert.AreEqual(4, ll.Peek(2));
            Assert.AreEqual(4, ll.PeekLast());
        }

        [TestMethod]
        public override void TestSplit()
        {
            ll = new();
            ll.Add(2);
            ll.Add(3);
            ll.Add(4);
            ll.Add(5);
            Node[] heads = ll.Split(1); // split after index 1 AKA 2nd node
            Assert.AreEqual(2, heads[0].Data);
            Assert.AreEqual(4, heads[1].Data);
            Assert.AreEqual(2, heads.Length);

            ll = new();
            ll.Add(2);
            ll.Add(3);
            Node[] heads2 = ll.Split(1);
            Assert.AreEqual(2, heads2[0].Data);
            Assert.AreEqual(1, heads2.Length);

            //ll = new();
            //ll.Add(2);
            // assert throws exception
            //Assert.AreEqual(2, heads3[0].Data);
            //Assert.AreEqual(1, heads3.Length);
        }

        [TestMethod]
        public override void TestMergeAsc()
        {
            LinkedListS<int> l = new();
            LinkedListS<int> a = new();
            a.Add(4);
            a.Add(8);
            a.Add(15);
            a.Add(19);
            LinkedListS<int> b = new();
            b.Add(7);
            b.Add(9);
            b.Add(10);
            b.Add(16);
            LinkedListS<int> merged = new();
            merged.Add(4);
            merged.Add(7);
            merged.Add(8);
            merged.Add(9);
            merged.Add(10);
            merged.Add(15);
            merged.Add(16);
            merged.Add(19);
            LLNode mergedList = l.MergeAsc(a, b);

            LLNode currentExp = merged.Head;
            LLNode currentAct = mergedList;
            while (currentExp != null)
            {
                Assert.AreEqual(currentExp.Data, currentAct.Data);
                currentExp = currentExp.Next;
                currentAct = currentAct.Next;
            }
        }

        [TestMethod]
        public override void TestIsLoop()
        {
            LinkedListS<int> l = new();
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);
            l.Current.Next.Next.Next = l.Head;
            Assert.IsTrue(l.IsLoop());

            LinkedListS<int> m = new();
            m.Add(2);
            m.Add(3);
            m.Add(4);
            Assert.IsFalse(m.IsLoop());
        }

        [TestMethod]
        public override void TestRemoveKthNodeFromEnd()
        {
            LinkedListS<int> l = new();
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);
            l.Add(6);
            LLNode removedNode = l.RemoveKthNodeFromEnd(5);
            Assert.AreEqual(4, l.Size);
            Assert.AreEqual(2, removedNode.Data);
            LLNode curr = l.Head;
            int data = 3;
            for (int i = 0; i < l.Size; i++)
            {
                Assert.AreEqual(data, curr.Data);
                curr = curr.Next;
                data++;
            }
        }

        [TestMethod]
        public override void TestGetIntersectionOfTwoListsSimple()
        {
            LinkedListS<int> l = new();
            LinkedListS<int> m = new();
            l.Add(2);
            l.Add(4);
            l.Add(6);
            l.Add(8);
            l.Add(10);
            m.Add(3);
            m.Add(5);
            m.Head.Next.Next = l.Head.Next.Next;
            Assert.AreEqual(m.Head.Next.Next, l.Head.Next.Next);
            Node intersection = l.GetIntersectionOfTwoListsSimple(l, m);
            Assert.AreEqual(m.Head.Next.Next, intersection);
        }

        [TestMethod]
        public override void TestGetIntersectionOfTwoListsStack()
        {
            LinkedListS<int> l = new();
            LinkedListS<int> m = new();
            l.Add(2);
            l.Add(4);
            l.Add(6);
            l.Add(8);
            l.Add(10); 
            m.Add(3);
            m.Add(5);
            m.Head.Next.Next = l.Head.Next.Next;
            Assert.AreEqual(m.Head.Next.Next, l.Head.Next.Next);
            Assert.IsNull(m.Head.Next.Next.Next.Next.Next);
            Assert.IsNull(l.Head.Next.Next.Next.Next.Next);
            Assert.IsNotNull(m.Head.Next.Next.Next.Next);
            Assert.IsNotNull(l.Head.Next.Next.Next.Next);
            //LLNode intersection = LinkedListS<int>.GetIntersectionOfTwoListsStack(l, m);
            //Assert.AreEqual(m.Head.Next.Next, intersection);
        }
    }
}
