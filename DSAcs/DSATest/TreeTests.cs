using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSAcs.Tree;
using DSAcs.Nodes;

namespace DSATest
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void TestTreeCreation()
        {
            Tree treeNullData = new();
            Assert.IsNotNull(treeNullData);
            Assert.IsNull(treeNullData.TraverseAndPrint(Tree.TraversalType.PREORDER));

            Tree tree = new(new TreeNode(1, // root
                new TreeNode(2, // l
                    new TreeNode(4, null, null), // l
                    null), // r
                new TreeNode(3, // root
                    new TreeNode(5, null, // l
                        new TreeNode(6, null, null) // r
                        ), null
                    )
                )
            );
            Assert.IsNotNull(tree);

        }
    }
}
