﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATest
{
    [TestClass]
    public abstract class LinkedListTestsBase
    {
        [TestMethod]
        public abstract void TestInstantiation();

        [TestMethod]
        public abstract void TestAdd();

        [TestMethod]
        public abstract void TestRemoveAndClean();

        [TestMethod]

        public abstract void TestSize();

        [TestMethod]
        public abstract void TestPeek();

        [TestMethod]
        public abstract void TestSplit();

        [TestMethod]
        public abstract void TestMergeAsc();

        [TestMethod]
        public abstract void TestIsLoop();

        [TestMethod]
        public abstract void TestRemoveKthNodeFromEnd();

        [TestMethod]
        public abstract void TestGetIntersectionOfTwoListsSimple();

        [TestMethod]
        public abstract void TestGetIntersectionOfTwoListsStack();
    }
}
