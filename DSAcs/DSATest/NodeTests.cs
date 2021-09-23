using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSAcs.Nodes;
using System;

// test class must:
// use Microsoft.VisualStudio.TestTools.UnitTesting;
// class decorated with [TestClass] attribute

// test method must meet requirements:
// decorated with [TestMethod] attribute
// returns void
// cannot have parameters

namespace DSATest
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void TestNodeCreation()
        {
            Node node = new NodeS();
            object data = node.Data;
            Assert.IsNull(data);
            data = "hello";
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestNodeS()
        {
            Node nodeS = new NodeS("hello");
            nodeS.Next = new NodeS("hi");
            Node curr = nodeS.Next;
            Assert.IsNotNull(curr);
        }

        [TestMethod]
        public void TestNodeD()
        {
            NodeD nodeD = new("hello");
            nodeD.Next = new NodeD("hi");
            NodeD curr = (NodeD) nodeD.Next;
            curr.Prev = nodeD;
            curr.Next = new NodeD("hey");
            Assert.AreEqual("hi", curr.Data);
            curr = curr.Prev;
            Assert.AreEqual("hello", curr.Data);
            curr = (NodeD) curr.Next.Next;
            Assert.AreEqual("hey", curr.Data);
        }

        [TestMethod]
        public void TestTreeNode()
        {
            TreeNode tNodeNull = new TreeNode();
            Assert.IsNotNull(tNodeNull);
            Assert.IsNull(tNodeNull.Data);

            TreeNode tNode = new TreeNode("hey");
            Assert.AreEqual("hey", tNode.Data);
            tNode.Left = new TreeNode("hi");
            tNode.Right = new TreeNode("hello");
            TreeNode curr = tNode;
            curr = curr.Left;
            Assert.AreEqual("hi", curr.Data);
            curr = tNode;
            curr = curr.Right;
            Assert.AreEqual("hello", curr.Data);
            Assert.IsNull(curr.Left);
            Assert.IsNull(curr.Right);
        }
    }
}
