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
            ll.Add(3);
            Assert.AreEqual(2, ll.Head.Data);
            Assert.AreEqual(3, ll.Head.Next.Data);

            // test add at nth location in list
            LinkedListS<int> ll2 = new();
            // assert throws exception if adding at a location larger than size or negative n
            ll2.Add(2);
            ll2.Add(3);
            ll2.Add(4, 1);
            Assert.AreEqual(2, ll2.Head.Data);
            Assert.AreEqual(4, ll2.Head.Next.Data);
            Assert.AreEqual(3, ll2.Head.Next.Next.Data); // order is 243 here
            ll2.Add(5, 0);
            Assert.AreEqual(5, ll2.Head.Data); // 5243
            Assert.AreEqual(2, ll2.Head.Next.Data);
            Assert.AreEqual(4, ll2.Head.Next.Next.Data);
            Assert.AreEqual(3, ll2.Head.Next.Next.Next.Data);
            ll2.Add(6, 5); // 52436
            Assert.AreEqual(6, ll2.Head.Next.Next.Next.Next.Data);
        }

        [TestMethod]
        public override void TestRemoveAndClean()
        {

        }

        [TestMethod]
        public override void TestSize()
        {

        }

        [TestMethod]
        public override void TestPeek()
        {

        }

        [TestMethod]
        public override void TestSplit()
        {

        }

        [TestMethod]
        public override void TestMerge()
        {

        }

        [TestMethod]
        public override void TestSorting()
        {

        }

        [TestMethod]
        public override void TestMergeSorting()
        {

        }

    }
}
