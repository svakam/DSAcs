using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSAcs.Queue;

namespace DSATest
{
    [TestClass]
    public class QueueTests
    {
        // consider instantiating both class types (generic vs. non-generic) in a list/arr and looping through test methods per class type
        [TestMethod]
        public void Instantiation()
        {
            Queue<int> queue = new();
            Assert.IsNotNull(queue);
            Assert.IsNull(queue.Front);
            Assert.IsNull(queue.Back);

            Queue<int> queue2 = new(2);
            Assert.IsNotNull(queue2);
            Assert.IsNotNull(queue2.Front.Data);
            Assert.IsNotNull(queue2.Back.Data);
        }
        [TestMethod]
        public void TestEnqueue()
        {
            Queue<string> queue = new("hi");
            queue.Enqueue("hello");
            Assert.AreEqual("hi", queue.Front.Data);
            Assert.AreEqual("hello", queue.Back.Data);
            queue.Enqueue("hey");
            Assert.AreEqual("hey", queue.Back.Data);
        }

        [TestMethod]
        public void TestDequeue()
        {
            Queue<int> queueNull = new();
            //Assert.ThrowsException(queue.Dequeue);

            Queue<int> queue = new(1);
            queue.Dequeue();
            Assert.IsNull(queue.Front);
            Assert.IsNull(queue.Back);
            queue.Enqueue(2);
            queue.Enqueue(4);
            Assert.AreEqual(2, queue.Front.Data);
            Assert.AreEqual(4, queue.Back.Data);
            Node node = queue.Dequeue();
            Assert.AreEqual(2, node.Data);
            Assert.AreEqual(4, queue.Front.Data);
            Assert.AreEqual(4, queue.Back.Data);
            queue.Enqueue(3);
            node = queue.Dequeue();
            Assert.AreEqual(4, node.Data);
            Assert.AreEqual(3, queue.Front.Data);
            Assert.AreEqual(3, queue.Back.Data);
            node = queue.Dequeue();
            Assert.AreEqual(3, node.Data);
            Assert.IsNull(queue.Front);
            Assert.IsNull(queue.Back);
        }

        [TestMethod]
        public void TestPeek()
        {
            Queue<string> queue = new("hi");
            object front = queue.Peek();
            Assert.AreEqual("hi", front);
            queue.Enqueue("hello");
            front = queue.Peek();
            Assert.AreEqual("hi", front);
            queue.Dequeue();
            front = queue.Peek();
            Assert.AreEqual("hello", front);
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            Queue<string> queue = new();
            Assert.IsTrue(queue.IsEmpty());
            queue.Enqueue("hi");
            Assert.IsFalse(queue.IsEmpty());
            queue.Dequeue();
            Assert.IsTrue(queue.IsEmpty());
        }
    }
}
