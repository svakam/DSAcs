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
        int[] expectedDesc = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, -1, -8 };
        [TestMethod]
        public void TestSelectionSortAsc()
        {
            int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            int[] actual = SelectionSort.Ascending(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expectedAsc[i], actual[i]);
            }
            arr = new int[] { -1, 2, -8, -10 };
            actual = SelectionSort.Ascending(arr);
            int[] expectedSmall = new int[] { -10, -8, -1, 2 };
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expectedSmall[i], actual[i]);
            }
        }

        //[TestMethod]
        //public void TestSelectionSortDesc()
        //{
        //    int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
        //    int[] actual = SelectionSort.Descending(arr);

        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        Assert.AreEqual(expectedAsc[i], actual[i]);
        //    }
        //}

        [TestMethod]
        public void TestBubbleSortAsc()
        {
            int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            int[] actual = BubbleSort.AscendingFlag(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expectedAsc[i], actual[i]);
            }
            arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            actual = BubbleSort.Ascending(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expectedAsc[i], actual[i]);
            }
        }

        //[TestMethod]
        //public void TestBubbleSortDesc()
        //{
        //    int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
        //    int[] actual = BubbleSort.Descending(arr);

        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        Assert.AreEqual(expectedAsc[i], actual[i]);
        //    }
        //}

        [TestMethod]
        public void TestInsertionSortAsc()
        {
            int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            int[] actual = InsertionSort.Ascending(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expectedAsc[i], actual[i]);
            }
        }

        // [TestMethod]
        // public void TestInsertionSortDesc()
        // {
        // }

        [TestMethod]
        public void TestMergeSortAsc()
        {
            int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            MergeSort.Ascending(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expectedAsc[i], arr[i]);
            }
        }

        [TestMethod]
        public void TestQuickSortAsc()
        {
            int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };

            // https://www.techiedelight.com/enumerate-an-enum-csharp/
            foreach (PivotMethod pivotMethod in Enum.GetValues(typeof(PivotMethod)))
            {
                Console.WriteLine($"Running test on {pivotMethod}.");
                QuickSort.Ascending(arr, pivotMethod);
                for (int i = 0; i < arr.Length; i++)
                {
                    Assert.AreEqual(expectedAsc[i], arr[i]);
                }
                
                // reset array to unsorted
                arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            }
            //QuickSort.Ascending(arr, PivotMethod.MIDDLE);
            //QuickSort.Ascending(arr, PivotMethod.FIRST);
            //QuickSort.Ascending(arr, PivotMethod.LAST);
            //QuickSort.Ascending(arr, PivotMethod.RANDOM);
            //QuickSort.Ascending(arr, PivotMethod.MEDIANOFTHREE);

        }

        [TestMethod]
        public void TestHeapSortAsc()
        {
            int[] arr = new int[] { -1, -8, 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            HeapSort.Ascending(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expectedAsc[i], arr[i]);
            }
        }
    }
}
