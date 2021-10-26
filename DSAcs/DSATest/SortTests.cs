﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSAcs.Sort;

namespace DSATest
{
    [TestClass]
    public class SortTests
    {
        int[] expectedAsc = new int[] { -8, -1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        [TestMethod]
        public void TestSelectionSortAsc()
        {
            int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            int[] actual = SelectionSort.Ascending(arr);
            int[] expected = new int[] { -8, -1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
            arr = new int[] { -1, 2, -8, -10 };
            actual = SelectionSort.Ascending(arr);
            expected = new int[] { -10, -8, -1, 2 };
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSelectionSortDesc()
        {
            int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            int[] actual = SelectionSort.Descending(arr);
            int[] expected = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, -1, -8 };
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestBubbleSortAsc()
        {
            int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            int[] actual = BubbleSort.AscendingFlag(arr);
            int[] expected = new int[] { -8, -1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
            arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            actual = BubbleSort.Ascending(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestBubbleSortDesc()
        {
            int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            int[] actual = BubbleSort.Descending(arr);
            int[] expected = new int[] { -8, -1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestInsertionSortAsc()
        {
            int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            int[] actual = InsertionSort.Ascending(arr);

        }

        // [TestMethod]
        // public void TestInsertionSortDesc()
        // {
        // }
    }
}