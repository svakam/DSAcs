using System;
using System.Collections.Generic;
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
        [TestMethod]
        public void Instantiation()
        {
            Queue queue = new();
            Assert.IsNotNull(queue);
            Assert.IsNull(queue.Front);
            Assert.IsNull(queue.Back);

            Queue queue2 = new(new NodeS(2));
            Assert.IsNotNull(queue2);
            Assert.IsNotNull(queue2.Front.Data);
            Assert.IsNotNull(queue2.Back.Data);
        }
        [TestMethod]
        public void TestEnqueue()
        {
            Queue queue = new Queue(new NodeS("hi"));
            queue.Enqueue("hello");
            Assert.AreEqual("hi", queue.Front.Data);
            Assert.AreEqual("hello", queue.Back.Data);
            queue.Enqueue("hey");
            Assert.AreEqual("hey", queue.Back.Data);
        }
    }
}
