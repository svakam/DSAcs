using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;
using DSAcs.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATest
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Instantiation()
        {
            Stack<string> stack = new();
            Assert.IsNotNull(stack);
            Assert.IsNull(stack.Top);

            Stack<int> stack2 = new(3);
            Assert.IsNotNull(stack2);
            Assert.IsNotNull(stack2.Top);
            Assert.AreEqual(3, stack2.Top.Data);
        }

        [TestMethod]
        public void TestPush()
        {
            Stack<int> stack = new(2);
            Assert.AreEqual(2, stack.Top.Data);
            stack.Push(3);
            Assert.AreEqual(3, stack.Top.Data);
            stack.Push(4);
            Assert.AreEqual(4, stack.Top.Data);
        }

        [TestMethod]

        public void TestPop()
        {
            Stack<int> stack = new(3);
            Node node = stack.Pop();
            Assert.AreEqual(3, node.Data);
            Assert.IsNull(stack.Top);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(3, stack.Pop().Data);
            Assert.AreEqual(2, stack.Pop().Data);
        }

        [TestMethod]
        public void TestPeek()
        {
            // Assert.ThrowsException -- assert invalidoperationexception is thrown if empty stack
            Stack<string> stack = new("hi");
            Assert.AreEqual("hi", stack.Peek());
            stack.Push("hello");
            Assert.AreEqual("hello", stack.Peek());
            stack.Pop();
            Assert.AreEqual("hi", stack.Peek());
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            Stack<int> stack = new();
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(2);
            Assert.IsFalse(stack.IsEmpty());
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }
    }
}
