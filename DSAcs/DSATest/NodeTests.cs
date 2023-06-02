using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSAcs.Nodes;
using System.Collections.Generic;

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
            LLNode node = new NodeS("hello");
            Assert.IsNotNull(node.Data);
        }

        [TestMethod]
        public void TestNodeS()
        {
            LLNode nodeS = new NodeS("hello");
            nodeS.Next = new NodeS("hi");
            LLNode curr = nodeS.Next;
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

        [TestMethod]
        public void TestTrieNode()
        {
            TrieNode tnNull = new TrieNode();
            Assert.IsNotNull(tnNull);

            // test insert
            TrieNode root = new();
            root.Children = new Dictionary<char, TrieNode>();
            TrieNode next = new();
            root.Children.Add('a', next); // root = {a, next}, F
            Assert.IsTrue(root.Children.ContainsKey('a'));
            Assert.IsFalse(root.EndOfWord);
            TrieNode eow = new();
            eow.EndOfWord = true;
            next.Children.Add('b', eow);
            Assert.AreEqual(root.Children['a'], next);
            Assert.IsTrue(root.Children['a'].Children['b'].EndOfWord);
        }
    }
}
