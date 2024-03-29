﻿using DSAcs.Nodes;
using DSAcs.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.IsNull(treeNullData.Traverse(TraversalType.PREORDER));

            Tree tree1 = new(new TreeNode(1));
            Assert.AreEqual("1", tree1.Traverse(TraversalType.PREORDER));

            Tree tree2 = new(new TreeNode(1, // root
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
            Assert.IsNotNull(tree2);
            Assert.AreEqual("124356", tree2.Traverse(TraversalType.PREORDER));
            Assert.AreEqual("421563", tree2.Traverse(TraversalType.INORDER));
            Assert.AreEqual("426531", tree2.Traverse(TraversalType.POSTORDER));
            //Assert.AreEqual("123456", tree2.Traverse(Tree.TraversalType.BREADTHFIRST)); -- resolve runtime vs. compile-time construct of queue
        }

        [TestMethod]
        public void TestCountFullNodes()
        {
            Tree tree = new(new TreeNode(1, 
                new TreeNode(2, 
                new TreeNode(3, 
                null, new TreeNode(4, 
                new TreeNode(5, 
                new TreeNode(7, null, null), new TreeNode(8, null, null)), new TreeNode(6, null, new TreeNode(9)))))));

            int fullNodes = tree.CountFullNodesDFS(tree);
            Assert.AreEqual(2, fullNodes);
        }

        [TestMethod]
        public void TestMaxDepth()
        {
            Tree tree = new(
                new TreeNode(1,
                    new TreeNode(2,
                        new TreeNode(3,
                            null, new TreeNode(4,
                                new TreeNode(5,
                                    new TreeNode(7, null, null), 
                                    new TreeNode(8, null, null)), 
                                new TreeNode(6, 
                                    null, 
                                    new TreeNode(9, null, null)
                                    )
                                )
                            )
                        )
                    )
                );

            int height = tree.GetMaxDepthRecursive(tree);
            Assert.AreEqual(6, height);
        }
        
        [TestMethod]
        public void TestMaxValueBT()
        {
            Tree tree = new(
                new TreeNode(1,
                    new TreeNode(2,
                        new TreeNode(3,
                            null, new TreeNode(1000,
                                new TreeNode(5,
                                    new TreeNode(7, null, null),
                                    new TreeNode(8, null, null)),
                                new TreeNode(6,
                                    null,
                                    new TreeNode(9, null, null)
                                    )
                                )
                            )
                        )
                    )
                );

            int max = tree.MaxValueOfBT(tree);
            Assert.AreEqual(1000, max);
        }

        [TestMethod]
        public void TestMaxValueBST()
        {
            Tree BST = new(
                new TreeNode(50,
                    new TreeNode(25,
                        new TreeNode(15,
                            new TreeNode(5, null, null),
                            new TreeNode(20, null, null)),
                        new TreeNode(35, 
                            new TreeNode(30, null, null), 
                            new TreeNode(40, null, null))
                        ), 
                    new TreeNode(75, 
                        new TreeNode(60, null, null),
                        new TreeNode(100, null, null)
                        )
                    )
                );
            int max = BST.MaxValueOfBST(BST);
            Assert.AreEqual(100, max);
        }
        [TestMethod]
        public void TestInsert()
        {
            Tree BST = new(
                new TreeNode(50,
                    new TreeNode(25,
                        new TreeNode(15,
                            new TreeNode(5, null, null),
                            new TreeNode(20, null, null)),
                        new TreeNode(35,
                            new TreeNode(30, null, null),
                            new TreeNode(40, null, null))
                        ),
                    new TreeNode(75,
                        new TreeNode(60, null, null),
                        new TreeNode(100, null, null)
                        )
                    )
                );
        }
    }
}
