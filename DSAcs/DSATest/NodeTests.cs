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
    }
}
